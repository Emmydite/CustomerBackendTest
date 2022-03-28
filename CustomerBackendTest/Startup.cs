using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.BLL.Contracts;
using Customer.BLL.Manager;
using Customer.BLL.Services;
using Customer.DAL.Contexts;
using Customer.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomerBackendTest
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
            var connStr = Configuration.GetConnectionString("CustomerDbContext");

            services.AddTransient<ICustomerService, CustomerServices>();
            services.AddTransient<IGoldService, GoldServices>();
            services.AddTransient<CustomerManager>();
            services.AddTransient<DbContext, CustomerDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connStr));

            //register swagger ui
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Customers API",
                    Version = "v1"
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                   );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API v1");
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
