// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Reflection;
using FluentAssertions;
using NLog;
using NLog.Config;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.NLog.Tests
{
	public class WebTests : LogTestsBase
	{
		public WebTests(ITestOutputHelper output) : base(output) { }

		private void TestLayout(bool withNLogWeb, Action<EcsLayout> setup, Action<EcsLayout> act)
		{
			if (withNLogWeb)
			{
				var nlogWebAssemblyName = new AssemblyName("NLog.Web.AspNetCore");
				var nlogWebAssembly = Assembly.Load(nlogWebAssemblyName);
#pragma warning disable CS0618 // Type or member is obsolete
				ConfigurationItemFactory.Default.RegisterItemsFromAssembly(nlogWebAssembly);
#pragma warning restore CS0618 // Type or member is obsolete
			}

			TestLoggerAndLayout(setup, (layout, logger, events) => act(layout));
		}

		[Theory]
		[InlineData(false)]
		[InlineData(true)]
		public void IncludeAspNetPropertiesIsTrueByDefault(bool withNLogWeb) =>
			TestLayout(withNLogWeb, null, layout =>
			{
				layout.IncludeAspNetProperties.Should().BeTrue();
			});

		[Theory(Skip = "Flakey On CI")]
		[InlineData(false)]
		[InlineData(true)]
		public void CanIncludeAspNetPropertiesRequiresNLogWebAspNet(bool withNLogWeb) =>
			TestLayout(withNLogWeb, null, layout =>
			{
				if (withNLogWeb)
				{
					layout.CanIncludeAspNetProperties().Should().BeTrue();
					layout.HttpRequestMethod.Should().NotBeNull();
				}
				else
				{
					layout.CanIncludeAspNetProperties().Should().BeFalse();
					layout.HttpRequestMethod.Should().BeNull();
				}
			});

		[Theory]
		[InlineData(false)]
		[InlineData(true)]
		public void CannotIncludeAspNetPropertiesWhenDisabled(bool withNLogWeb) =>
			TestLayout(withNLogWeb,
				layout =>
				{
					layout.IncludeAspNetProperties = false;
				},
				layout =>
				{
					layout.IncludeAspNetProperties.Should().BeFalse();
					layout.HttpRequestMethod.Should().BeNull();
				});
	}
}
