using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Petiza.Catalogo.Api.Configuration;
using Petiza.Catalogo.Application.Services;
using Petiza.Catalogo.Data;
using Petiza.Catalogo.Data.Repository;
using Petiza.Catalogo.Domain;
using Petiza.Core.Services;
using Polly;

namespace Petiza.Catalogo.Api
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
            services.AddSwaggerGen();
            services.AddAutoMapperSetup();
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddHostedService<QueueHostedService>();
            services.AddScoped<IAnimalApplicationService, AnimalApplicationService>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddDbContext<CatalogoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dg Bar");
            });

            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
            //    RequestPath = new PathString("/Resources")
            //});
            var policy = Policy.Handle<Exception>().WaitAndRetryForever(retryAttempt => TimeSpan.FromSeconds(5), onRetry: (exception, timespan) =>
                Console.WriteLine("Falha ao realizar migration: " + exception.Message));

            policy.Execute(() => Executar(app));
            
        }

        private void Executar(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<CatalogoContext>().Database.Migrate();
            }
        }
    }
}
