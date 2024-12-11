using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace DemoOcelotGatewayApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHealthChecks();

            builder.Services.AddOcelot(builder.Configuration);

            // Add JSON file for Ocelot configuration
           builder.Configuration.AddJsonFile("Configuration.json", optional: false, reloadOnChange: true);

            var app = builder.Build();

            //app.MapControllers();
            app.UseRouting();
            app.MapHealthChecks("/healthz");
            app.UseEndpoints(endpoints => { app.MapControllers(); });

            app.UseOcelot().Wait();

            app.Run();
            
        }
    }
}
