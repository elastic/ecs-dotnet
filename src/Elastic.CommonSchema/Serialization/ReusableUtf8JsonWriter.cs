// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	internal sealed class ReusableUtf8JsonWriter
	{
		private Utf8JsonWriter _cachedJsonWriter;
		private readonly MemoryStream _cachedMemoryStream;
		private readonly char[] _cachedEncodingBuffer;

		public ReusableUtf8JsonWriter()
		{
			_cachedMemoryStream = new MemoryStream(4 * 1024);
			_cachedJsonWriter = new Utf8JsonWriter(_cachedMemoryStream);
			_cachedEncodingBuffer = new char[1024];
		}

		public ReusableJsonWriter AllocateJsonWriter(StringBuilder text)
		{
			var writer = System.Threading.Interlocked.Exchange(ref _cachedJsonWriter, null);
			return new ReusableJsonWriter(this, writer, text);
		}

		public ReusableJsonWriter NewJsonWriter(StringBuilder text) =>
			new ReusableJsonWriter(this, new Utf8JsonWriter(new MemoryStream()), text);

		private void Return(Utf8JsonWriter writer, StringBuilder output)
		{
			writer.Flush();

			if (_cachedMemoryStream.Length > 0)
			{
				if (!_cachedMemoryStream.TryGetBuffer(out var byteArray))
					byteArray = new ArraySegment<byte>(_cachedMemoryStream.GetBuffer(), 0, (int)_cachedMemoryStream.Length);

				CopyToStringBuilder(byteArray, _cachedEncodingBuffer, output);
			}

			writer.Reset();
			_cachedMemoryStream.Position = 0;
			_cachedMemoryStream.SetLength(0);
			System.Threading.Interlocked.Exchange(ref _cachedJsonWriter, writer);
		}

		private static void CopyToStringBuilder(ArraySegment<byte> byteArray, char[] encodingBuffer, StringBuilder output)
		{
			for (var i = 0; i < byteArray.Count; i += encodingBuffer.Length)
			{
				var byteCount = Math.Min(byteArray.Count - i, encodingBuffer.Length);
				var charCount = Encoding.UTF8.GetChars(byteArray.Array!, byteArray.Offset + i, byteCount, encodingBuffer, 0);
				output.Append(encodingBuffer, 0, charCount);
			}
		}

		internal readonly struct ReusableJsonWriter : IDisposable
		{
			private readonly ReusableUtf8JsonWriter _owner;
			private readonly Utf8JsonWriter _writer;
			private readonly StringBuilder _output;

			public ReusableJsonWriter(ReusableUtf8JsonWriter owner, Utf8JsonWriter writer, StringBuilder output)
			{
				_writer = writer;
				_owner = writer != null ? owner : null;
				_output = output;
			}

			public void Serialize(EcsDocument ecsEvent)
			{
				if (_writer != null)
					ecsEvent.Serialize(_writer);
				else
				{
					var result = ecsEvent.Serialize();
					_output.Append(result);
				}
			}

			public void Dispose() => _owner?.Return(_writer, _output);
		}
	}
}
