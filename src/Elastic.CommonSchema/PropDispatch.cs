// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated.
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Elastic.CommonSchema.Serialization;

namespace Elastic.CommonSchema
{
	internal static partial class PropDispatch
	{
		public static void SetMetaOrLabel(EcsDocument document, string path, object value)
		{
			switch (value)
			{
				case string s:
					document.Labels ??= new Labels();
					document.Labels[path] = s;
					break;
				case bool b:
					document.Labels ??= new Labels();
					document.Labels[path] = b.ToString(CultureInfo.InvariantCulture).ToLowerInvariant();
					break;
				default:
					document.Metadata ??= new MetadataDictionary();
					document.Metadata[path] = value;
					break;
			}
		}

		private static bool TrySetLong<T>(T target, object value, Action<T, long> set)
		{
			if (!TrySetLong(value, out var b)) return false;
			set(target, b);
			return true;
		}

		private static bool TrySetLong(object value, out long l)
		{
			l = default;
			switch (value)
			{
				case long ll:
					l = ll;
					return true;
				case int i:
					l = l = i;
					return true;
				case string s when long.TryParse(s, NumberStyles.None, CultureInfo.InvariantCulture, out var ll):
					l = ll;
					return true;
				default:
					return false;
			}
		}

		private static bool TrySetFloat(object value, out float f)
		{
			f = default;
			switch (value)
			{
				case float ff:
					f = ff;
					return true;
				case long l:
					f = Convert.ToSingle(l);
					return true;
				case int i:
					f = Convert.ToSingle(i);
					return true;
				case string s when float.TryParse(s, NumberStyles.None, CultureInfo.InvariantCulture, out var ll):
					f = ll;
					return true;
				default:
					return false;
			}
		}

		private static bool TrySetFloat<T>(T target, object value, Action<T, float> set)
		{
			if (!TrySetFloat(value, out var b)) return false;
			set(target, b);
			return true;
		}

		private static bool TrySetBool(object value, out bool b)
		{
			b = default;
			switch (value)
			{
				case bool bb:
					b = bb;
					return true;
				case string s when bool.TryParse(s, out var ll):
					b = ll;
					return true;
				default:
					return false;
			}
		}

		private static bool TrySetBool<T>(T target, object value, Action<T, bool> set)
		{
			if (!TrySetBool(value, out var b)) return false;
			set(target, b);
			return true;
		}

		private static bool TrySetString<T>(T target, object value, Action<T, string> set)
		{
			if (!TrySetString(value, out var s) || s == null) return false;
			set(target, s);
			return true;
		}

		private static bool TrySetString(object value, out string b)
		{
			b = value switch
			{
				string s => s,
				_ => null
			};
			return b != null;
		}

		private static bool TrySetDateTimeOffset<T>(T target, object value, Action<T, DateTimeOffset> set)
		{
			if (!TrySetDateTimeOffset(value, out var d)) return false;
			set(target, d);
			return true;

		}

		private static bool TrySetDateTimeOffset(object value, out DateTimeOffset d)
		{
			d = default;
			switch (value)
			{
				case long l:
					d = DateTimeOffset.FromUnixTimeMilliseconds(l);
					return true;
				case int i:
					d = DateTimeOffset.FromUnixTimeMilliseconds(i);
					return true;
				case DateTime dt:
					d = new DateTimeOffset(dt);
					return true;
				case string s:
				{
					var formats = new[]
					{
						"yyyy-MM-ddTHH:mm:ss.FFFK",
						"yyyy-MM-dd'T'HH:mm:ss.FFFK"
					};
					d = DateTimeOffset.ParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
					return true;
				}
				default: return false;
			}
		}

	}
}
