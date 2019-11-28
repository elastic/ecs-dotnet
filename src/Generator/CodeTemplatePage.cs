using System;
using System.Threading.Tasks;
using RazorLight;

namespace Generator
{
    /// <summary>
    ///   This only exists to make the IDE tooling happy, not actually used to render the templates.
    /// </summary>
    public class CodeTemplatePage<TModel> : TemplatePage<TModel>
    {
        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task Execute()
        {
            return Task.CompletedTask;
        }
    }
}