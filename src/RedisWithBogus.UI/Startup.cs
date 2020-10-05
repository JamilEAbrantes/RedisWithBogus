using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisWithBogus.Application.Interfaces;
using RedisWithBogus.Application.Services;
using RedisWithBogus.Domain.Interfaces;
using RedisWithBogus.Repository.Interfaces;

namespace RedisWithBogus.UI
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("Cache:RedisConnection").Value;
                options.InstanceName = "rediswithbogus:";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
