﻿using System;
using System.Threading;
using Elastic.Ingest.Apm.Helpers;
using Elastic.Ingest.Apm.Model;
using Elastic.Transport;

namespace Elastic.Ingest.Apm.Example
{
	internal class Program
	{
		private static int _rejections;
		private static int _requests;
		private static int _responses;
		private static int _retries;
		private static int _maxRetriesExceeded;
		private static Exception _exception;

		private static int Main(string[] args)
		{
			if (args.Length != 2)
			{
				Console.Error.WriteLine("Please specify <url> <secret_token>");
				return 1;
			}

			var config = new TransportConfiguration(new Uri(args[0]))
				.EnableDebugMode()
				.Authentication(new ApiKey(args[1]));
			var transport = new Transport<TransportConfiguration>(config);

			var numberOfEvents = 800;
			var maxBufferSize = 200;
			var handle = new CountdownEvent(numberOfEvents / maxBufferSize);

			var options =
				new ApmBufferOptions()
				{
					ConcurrentConsumers = 1,
					MaxConsumerBufferSize = 200,
					MaxConsumerBufferLifetime = TimeSpan.FromSeconds(10),
					WaitHandle = handle,
					MaxRetries = 3,
					BackoffPeriod = times => TimeSpan.FromMilliseconds(1),
					ServerRejectionCallback = (list) => Interlocked.Increment(ref _rejections),
					BulkAttemptCallback = (c, a) => Interlocked.Increment(ref _requests),
					ResponseCallback = (r, b) =>
					{
						Interlocked.Increment(ref _responses);
						Console.WriteLine(r.ApiCall.DebugInformation);
					},
					BufferFlushCallback = () => Console.WriteLine("Flushed"),
					MaxRetriesExceededCallback = (list) => Interlocked.Increment(ref _maxRetriesExceeded),
					RetryCallBack = (list) => Interlocked.Increment(ref _retries),
					ExceptionCallback = (e) => _exception = e
				};
			var channelOptions = new ApmChannelOptions(transport)
			{
				BufferOptions = options
			};
			var channel = new ApmChannel(channelOptions);

			string Id() => RandomGenerator.GenerateRandomBytesAsString(8);
			var random = new Random();
			for (var i = 0; i < numberOfEvents; i++)
			{
				channel.TryWrite(new Transaction("http", Id(), Id(), new SpanCount(), random.NextDouble() * random.Next(100, 1000) , Epoch.UtcNow) { Name = "x" });
			}
			handle.Wait(TimeSpan.FromSeconds(20));

			return 0;
		}
	}

	internal static class RandomGenerator
	{
		[ThreadStatic]
		private static Random _local;

		private static readonly Random Global = new Random();

		internal static Random GetInstance()
		{
			var inst = _local;
			if (inst == null)
			{
				int seed;
				lock (Global) seed = Global.Next();
				_local = inst = new Random(seed);
			}
			return inst;
		}

		internal static void GenerateRandomBytes(byte[] bytes) => GetInstance().NextBytes(bytes);

		/// <summary>
		/// Creates a random generated byte array hex encoded into a string.
		/// </summary>
		/// <param name="bytes">
		/// The byte array that will be filled with a random number - this defines the length of the generated
		/// random bits
		/// </param>
		/// <returns>The random number hex encoded as string</returns>
		internal static string GenerateRandomBytesAsString(byte[] bytes)
		{
			GenerateRandomBytes(bytes);
			return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
		}

		internal static string GenerateRandomBytesAsString(int numberOfBytes) => GenerateRandomBytesAsString(new byte[numberOfBytes]);

		internal static double GenerateRandomDoubleBetween0And1() => GetInstance().NextDouble();
	}
}
