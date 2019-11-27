using System;
using System.Runtime.CompilerServices;

#if DOTNETCORE
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif

namespace Elastic.CommonSchema.Serilog
{
    public interface IECSJsonFormatterConfiguration
    {
        bool MapExceptions { get; set; }
        bool MapCurrentThread { get; set; }
        IHttpAdapter MapHttpAdapter { get; set; }
        Func<Base, Base> MapCustom { get; set; }
    }
    
    public class ECSJsonFormatterConfiguration : IECSJsonFormatterConfiguration
    {
        bool IECSJsonFormatterConfiguration.MapExceptions { get; set; } = true;
        bool IECSJsonFormatterConfiguration.MapCurrentThread { get; set; } = true;
        
        IHttpAdapter IECSJsonFormatterConfiguration.MapHttpAdapter { get; set; }

        Func<Base, Base> IECSJsonFormatterConfiguration.MapCustom { get; set; } = b => b;

#if DOTNETCORE
        public ECSJsonFormatterConfiguration MapHttpContext(IHttpContextAccessor contextAccessor) => Assign(this, contextAccessor, (o, v) => o.MapHttpAdapter = new HttpAdapter(v));
#else
        public ECSJsonFormatterConfiguration MapHttpContext(HttpContext httpContext) => Assign(this, httpContext, (o, v) => o.MapHttpAdapter = new HttpAdapter(v));
#endif
        public ECSJsonFormatterConfiguration MapExceptions(bool value) => Assign(this, value, (o, v) => o.MapExceptions = v);
        public ECSJsonFormatterConfiguration MapCurrentThread(bool value) => Assign(this, value, (o, v) => o.MapCurrentThread = v);
        public ECSJsonFormatterConfiguration MapCustom(Func<Base, Base> value) => Assign(this, value, (o, v) => o.MapCustom = v);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ECSJsonFormatterConfiguration Assign<TValue>(
            ECSJsonFormatterConfiguration self, TValue value, Action<IECSJsonFormatterConfiguration, TValue> assign)
        {
            assign(self, value);
            return self;
        }
    }
}