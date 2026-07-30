using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests;

public class Md5VsSha256
{
	private readonly SHA256 _sha256 = SHA256.Create();
	private readonly MD5 _md5 = MD5.Create();
	private byte[] _data;

	public int N { get; set; } = 100;

	[GlobalSetup]
	public void Setup()
	{
		_data = new byte[N];
		new Random(42).NextBytes(_data);
	}

	[Benchmark]
	public byte[] Sha256() => _sha256.ComputeHash(_data);

	[Benchmark]
	public byte[] Md5() => _md5.ComputeHash(_data);
}
