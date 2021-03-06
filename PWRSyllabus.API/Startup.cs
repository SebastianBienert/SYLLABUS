using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PWRSyllabus.Core;
using PWRSyllabus.Core.Interfaces;
using PWRSyllabus.Core.UseCases.CreateMinisterialEffect;
using PWRSyllabus.Core.UseCases.UpdateMinisterialEffect;
using PWRSyllabus.Infrastructure.EntityFramework;
using System;
using DinkToPdf;
using DinkToPdf.Contracts;
using PWRSyllabus.Core.UseCases;
using PWRSyllabus.Core.UseCases.GenerateSubjectCardReport;
using VueCliMiddleware;

namespace PWRSyllabusAPI
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
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            // Add AddRazorPages if the app uses Razor Pages.
            services.AddRazorPages();
            services.AddScoped<ICRUDRepository, CRUDRepository>();
            services.AddScoped<IMinisterialEffectRepository, MinisterialEffectRepository>();
            services.AddScoped<IStudyProgramRepository, StudyProgramRepository>();
            services.AddScoped<ISubjectCardRepository, SubjectCardRepository>();
            services.AddScoped<IFieldOfStudyRepository, FieldOfStudyRepository>();
            services.AddScoped<ITraceMatrixRepository, TraceMatrixRepository>();
            services.AddScoped<CreateMinisterialEffectUseCase>();
            services.AddScoped<UpdateMinisterialEffectUseCase>();
            services.AddScoped<GenerateSubjectCardPDFUSeCase>();
            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<PWRSyllabusContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("PWRSyllabus.Infrastructure")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
               // app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "ClientApp" },
                        npmScript: "serve",
                        port: 8181,
                        regex: "Compiled successfully");
                }

                // Add MapRazorPages if the app uses Razor Pages. Since Endpoint Routing includes support for many frameworks, adding Razor Pages is now opt -in.
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}
