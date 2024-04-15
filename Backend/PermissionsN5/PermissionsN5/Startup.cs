﻿using Domain.Business;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.OpenApi.Models;

namespace PermissionsN5
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
            //services.Configure<IConfiguration>(Configuration.GetSection("ConnectionStrings"));
            services.AddDbContext<PermissionContext>();
            services.AddScoped<IPermisosBL<PermisoModels>, PermisosBL>();
            //services.AddSingleton<IPermisosBL<PermisoModels>, PermisosBL>();
            //services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PermisosAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PermisosAPI v1"));
            }
            app.UseCors(options => {
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
            });

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
