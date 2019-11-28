// Licensed to Elasticsearch B.V. under one or more contributor
// license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright
// ownership. Elasticsearch B.V. licenses this file to you under
// the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

using System;
using System.Runtime.CompilerServices;

#if NETSTANDARD
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif

namespace Elastic.CommonSchema.Serilog
{
    public interface IEcsTextFormatterConfiguration
    {
        bool MapExceptions { get; set; }
        bool MapCurrentThread { get; set; }
        IHttpAdapter MapHttpAdapter { get; set; }
        Func<Base, Base> MapCustom { get; set; }
    }
    
    public class EcsTextFormatterConfiguration : IEcsTextFormatterConfiguration
    {
        bool IEcsTextFormatterConfiguration.MapExceptions { get; set; } = true;
        bool IEcsTextFormatterConfiguration.MapCurrentThread { get; set; } = true;
        
        IHttpAdapter IEcsTextFormatterConfiguration.MapHttpAdapter { get; set; }

        Func<Base, Base> IEcsTextFormatterConfiguration.MapCustom { get; set; } = b => b;

#if NETSTANDARD
        public EcsTextFormatterConfiguration MapHttpContext(IHttpContextAccessor contextAccessor) => Assign(this, contextAccessor, (o, v) => o.MapHttpAdapter = new HttpAdapter(v));
#else
        public EcsTextFormatterConfiguration MapHttpContext(HttpContext httpContext) => Assign(this, httpContext, (o, v) => o.MapHttpAdapter = new HttpAdapter(v));
#endif
        public EcsTextFormatterConfiguration MapExceptions(bool value) => Assign(this, value, (o, v) => o.MapExceptions = v);
        public EcsTextFormatterConfiguration MapCurrentThread(bool value) => Assign(this, value, (o, v) => o.MapCurrentThread = v);
        public EcsTextFormatterConfiguration MapCustom(Func<Base, Base> value) => Assign(this, value, (o, v) => o.MapCustom = v);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EcsTextFormatterConfiguration Assign<TValue>(
            EcsTextFormatterConfiguration self, TValue value, Action<IEcsTextFormatterConfiguration, TValue> assign)
        {
            assign(self, value);
            return self;
        }
    }
}