using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreUriToAssoc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(options => 
                    options.ValueProviderFactories.Add(new PathValueProviderFactory()));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "properties-search",
                    template: "{controller=Properties}/{action=Search}/{*path}"
                );
            });
        }
    }
}
