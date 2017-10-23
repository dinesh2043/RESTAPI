using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TestApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace TestApplication
{
    //Startup.cs file is about registering services and injection of modules in HTTP pipeline. 
    //Startup.cs file contains Startup class which triggers at first when application launches and 
    //even in each HTTP request/response.
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // In-memory database services is configured in Database context
            // it also uses MVC
            services.AddDbContext<DeploymentsContext>(opt => opt.UseInMemoryDatabase("Deployment"));
            services.AddMvc();
        }
        // The Config method is used to specify how the application will respond in each HTTP request. 
        // Which implies that Configure method is HTTP request specific
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
