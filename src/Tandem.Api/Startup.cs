using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Tandem.Api.Middleware;
using Tandem.Application.Users.Commands;
using Tandem.Domain.Users;
using Tandem.Infrastructure.CosmosDB.Users;

namespace Tandem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(
                typeof(CreateUserCommand).Assembly);
            services.AddSingleton<IUserRepository, CosmosDBUserRepository>();
            services.AddSingleton<CosmosClient>(
                new CosmosClient(
                    Configuration["Cosmos:Endpoint"],
                    Configuration["Cosmos:Key"],
                    new CosmosClientOptions() {ApplicationName = "Tandem"})
            );
            services.AddOpenApi();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
        }
    }
}