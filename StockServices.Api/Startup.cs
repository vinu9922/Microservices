using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StockServices.Core.Contracts;
using StockServices.Core.Entites;
using StockServices.Core.Services;
using StockServices.Infrastructure.Contexts;
using StockServices.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockServices.Api
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
            services.AddDbContext<StocksContext>(settings => settings.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<Stocks>, GenericRepository<Stocks>>();
            services.AddScoped<IStockService, StockService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(settings => settings.SwaggerDoc("v1", new OpenApiInfo() { 
                Title="Stocks Services",
                Description="New1",
                Version="V1"
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(settings => settings.SwaggerEndpoint("/swagger/v1/swagger.json", "StockService"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
