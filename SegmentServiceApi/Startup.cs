using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SegmentService.Infrastructure.Context;
using SegmentService.Infrastructure.Repositories;
using SegmentServiceCore.Contracts;
using SegmentServiceCore.Entities;
using SegmentServiceCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegmentServiceApi
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
            services.AddDbContext<SegmentContext>(settings => settings.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRepository<Segment>, GenericRepository<Segment>>();
            services.AddScoped<ISegmentService,AddSegmentServices>();
             services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(settings => settings.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Segment services",
                Description = "seg ser created",
                Contact = new OpenApiContact { Email = "godse.vinu@gmail.com" }
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(settings => settings.SwaggerEndpoint("/swagger/v1/swagger.json", "Segment Services"));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
