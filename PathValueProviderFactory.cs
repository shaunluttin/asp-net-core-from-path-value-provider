using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreUriToAssoc
{
    public class PathValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            var provider = new PathValueProvider(
                BindingSource.Custom, 
                context.ActionContext.RouteData.Values);

            context.ValueProviders.Add(provider);

            return Task.CompletedTask;
        }
    }
}
