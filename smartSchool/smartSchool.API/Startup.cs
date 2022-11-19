using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using smartSchool.API.Data;
using System;
using System.IO;
using System.Reflection;

namespace smartSchool.API
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
            services.AddDbContext<DataContext>(
                context => context.UseMySql(Configuration.GetConnectionString("MySqlConnection"))
                );

            services.AddControllers().AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Via refletion qual(is) classe : Profile para mapeamento.

            services.AddScoped<IRepository, Repository>();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("SmartSchoolAPI",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "SmartSchool Api",
                        Version = "1.0",
                        TermsOfService = new Uri("https://github.com/nicaodev"),
                        Description = "Descrição etc etc"
                    });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                opt.IncludeXmlComments(xmlCommentsPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger().
                UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/SmartSchoolAPI/swagger.json", "smartschoolapi");
                    opt.RoutePrefix = "";
                });

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}