using GolaCorp.ScoreKeeper.Domain.Services;
using GolaCorp.ScoreKeeper.Infrastructure.Repositories;
using GolaCorp.ScoreKeeper.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GolaCorp.ScoreKeeper.Api", Version = "v1" });
            });
                        
            services.Configure<ScoreKeeperDatabaseSettings>(
                Configuration.GetSection(nameof(ScoreKeeperDatabaseSettings)));

            services.AddSingleton<IScoreKeeperDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ScoreKeeperDatabaseSettings>>().Value);

            


            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ScoreKeeperDb");
            services.AddScoped(db => database);
            services.AddTransient(typeof(IDocumentRepository<>), typeof(DocumentRepository<>));
            services.AddTransient<IGamesService, GamesService>();
            services.AddTransient<IScoreUpdatorService, ScoreUpdatorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GolaCorp.ScoreKeeper.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
