using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notifi.NET.DatabaseContext;

namespace Towiccho.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Change example data for config options
            var databaseUser = "postgres";
            var databasePassword = "123456";
            var databaseHost = "localhost";
            var databasePort = "5432";
            var databaseName = "Towiccho";

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<NotifiDatabaseContext>(opt =>
                    opt.UseNpgsql(
                        $"User ID={databaseUser};Password={databasePassword};Server={databaseHost};Port={databasePort};Database={databaseName};Integrated Security=true;Pooling=true;",
                        o => o.MigrationsAssembly("Towiccho.Server")
                        )
                );

            services.AddSingleton(TowicchoSingletons.HttpClient);
            services.AddSingleton(TowicchoSingletons.Random);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
