// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

#if NETSTANDARD
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
	public interface IEcsTextFormatterConfiguration
	{
		bool MapCurrentThread { get; set; }
		Func<Base, LogEvent, Base> MapCustom { get; set; }
		bool MapExceptions { get; set; }
		IHttpAdapter MapHttpAdapter { get; set; }
		ISet<string> LogEventPropertiesToFilter { get;set; }
	}

	public class EcsTextFormatterConfiguration : IEcsTextFormatterConfiguration
	{
		bool IEcsTextFormatterConfiguration.MapExceptions { get; set; } = true;
		bool IEcsTextFormatterConfiguration.MapCurrentThread { get; set; } = true;

		IHttpAdapter IEcsTextFormatterConfiguration.MapHttpAdapter { get; set; }
		ISet<string> IEcsTextFormatterConfiguration.LogEventPropertiesToFilter { get; set; }

		Func<Base, LogEvent, Base> IEcsTextFormatterConfiguration.MapCustom { get; set; } = (b, e) => b;

#if NETSTANDARD
        public EcsTextFormatterConfiguration MapHttpContext(IHttpContextAccessor contextAccessor) => Assign(this, contextAccessor, (o, v) => o.MapHttpAdapter
 = new HttpAdapter(v));
#else
		public EcsTextFormatterConfiguration MapHttpContext(HttpContext httpContext) =>
			Assign(this, httpContext, (o, v) => o.MapHttpAdapter = new HttpAdapter(v));
#endif
		public EcsTextFormatterConfiguration MapExceptions(bool value) => Assign(this, value, (o, v) => o.MapExceptions = v);

		public EcsTextFormatterConfiguration MapCurrentThread(bool value) => Assign(this, value, (o, v) => o.MapCurrentThread = v);

		public EcsTextFormatterConfiguration MapCustom(Func<Base, LogEvent, Base> value) => Assign(this, value, (o, v) => o.MapCustom = v);

		public EcsTextFormatterConfiguration LogEventPropertiesToFilter(ISet<string> value) => Assign(this, value, (o, v) => o.LogEventPropertiesToFilter = v);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static EcsTextFormatterConfiguration Assign<TValue>(
			EcsTextFormatterConfiguration self, TValue value, Action<IEcsTextFormatterConfiguration, TValue> assign
		)
		{
			assign(self, value);
			return self;
		}
	}
}
