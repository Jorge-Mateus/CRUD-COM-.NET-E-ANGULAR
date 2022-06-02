using EstruturaOrganizacional.Persistence.Contextos;
using EstruturaOrganizacional.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EstruturaOrganizacional.Application.Contratos;
using EstruturaOrganizacional.Application;
using AutoMapper;
using EstruturaOrganizacional.Persistence.Contratos;
using System;

namespace EstruturaOrganizacional.API
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

              //Conexão banco de dados

            services.AddDbContext<EstruturaOrganizacionalContext>(

                x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConn"))

            );

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IBusinessAreaService, BusinessAreaService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IBusinessAreaPersist, BusinessAreaPersist>();

            services.AddScoped<IMarketAreaService, MarketAreaService>();
            services.AddScoped<IGeralPersist, GeralPersist>();//TALVEZ CAUSE CONFLITO
            services.AddScoped<IMarketAreaPersist, MarketAreaPersist>();

            services.AddScoped<IOperatingUnitService, OperatingUnitsService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IOperatingUnitPersist, OperatingUnitPersist>();

            services.AddScoped<ITechnologicalAreaService, TechnologicalAreaService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<ITechnologicalAreaPersist, TechnologicalAreaPersist>();

            services.AddScoped<IOrganizationalStructureService, OrganizationalStructureService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IOrganizationalStructurePersist, OrganizationalStructurePersist>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EstruturaOrganizacional.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstruturaOrganizacional.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}