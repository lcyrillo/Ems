using AutoMapper;
using CS.Ems.Application.AutoMapper;
using CS.Ems.Application.Interfaces;
using CS.Ems.Application.Services;
using CS.Ems.Domain.Interfaces.Repository;
using CS.Ems.Domain.Interfaces.Services;
using CS.Ems.Domain.Interfaces.UoW;
using CS.Ems.Domain.Services;
using CS.Ems.Infrastructure.Data.Context;
using CS.Ems.Infrastructure.Data.Repositories;
using CS.Ems.Infrastructure.Data.UoW;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CS.Ems.Profile.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //fluent validation
            services.AddMvc(setup => { }).AddFluentValidation();

            //AutoMapper
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToViewModelMappingProfile());
                config.AddProfile(new ViewModelToDomainMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Technical Profile API",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            //validators register
            //services.AddScoped<IValidator<Domain.Entities.TechnicalProfile>, TechnicalProfileValidator>();

            //connection string
            services.AddDbContext<EmsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmsConn")));

            //services
            services.AddScoped<ITechnicalProfileAppService, TechnicalProfileAppService>();
            services.AddScoped<ITechnicalProfileService, TechnicalProfileService>();
            services.AddScoped<ITechnicalProfileRepository, TechnicalProfileRepository>();

            services.AddScoped<IModuleAppService, ModuleAppService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IModuleRepository, ModuleRepository>();

            //unity of work
            services.AddScoped<IUnityOfWork, UnityOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMS API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
