using System;
using AutoMapper;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta.Services;
using MiCanasta.MiCanasta.Services.Impl;
using MiCanasta.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MiCanasta
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

            services.AddTransient<SolicitudService, SolicitudServiceImpl>();
            services.AddTransient<UsuarioService, UsuarioServiceImpl>();
            services.AddTransient<FamiliaService, FamiliaServiceImpl>();
            services.AddTransient<UsuarioFamiliaService, UsuarioFamiliaServiceImpl>();
            services.AddTransient<TiendaService, TiendaServiceImpl>();
            services.AddTransient<ProductoService, ProductoServiceImpl>();
            services.AddTransient<CategoriaService, CategoriaServiceImpl>();
            services.AddTransient<HistorialService, HistorialServiceImpl>();


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddDbContextPool<ApplicationDbContext>(options => options
                     .UseMySql("Server=remotemysql.com;Database=Zct6qUV10Y;User=Zct6qUV10Y;Password=H3KbNV9dLI;", mySqlOptions => mySqlOptions
                         .ServerVersion(new Version(8, 0, 13), ServerType.MySql)
             ));

            /*services.AddDbContextPool<ApplicationDbContext>(options => options
            .UseMySql("Server=localhost;Database=mi-canasta-web;User=root;Password=root;", mySqlOptions => mySqlOptions
            .ServerVersion(new Version(8, 0, 13), ServerType.MySql)
            ));*/


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Mi Canasta",
                    Version = "v1"
                });
            });

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi Canasta");
            });

        }

    }
}
