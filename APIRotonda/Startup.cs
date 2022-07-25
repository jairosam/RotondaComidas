using APIRotonda.Context;
using APIRotonda.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace APIRotonda
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
            services.AddResponseCaching();
            services.AddControllers(opciones =>
            {
                opciones.Filters.Add(typeof(ExceptionFilter));
                opciones.CacheProfiles.Add("Default10",
                    new CacheProfile()
                    {
                        Duration = 10,
                        Location = ResponseCacheLocation.Any,
                        NoStore = false
                    });
            }).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Rotonda", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(x => x.AddPolicy(name:"AllowWebApp",
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseCors("AllowWebApp");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 

        }
    }
}
