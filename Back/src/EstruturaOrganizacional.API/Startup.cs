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
using EstruturaOrganizacional.Persistence.Contratos;

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
            services.AddControllers();


            services.AddScoped<IBusinessAreaService, BusinessAreaService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IBusinessAreaPersist, BusinessAreaPersist>();
            
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

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
