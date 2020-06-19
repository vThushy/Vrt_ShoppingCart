using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contexts;
using ShoppingCart.Extensions;
using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using ShoppingCart.Repository;

namespace ShoppingCart
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
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            //services.AddDbContext<AddressDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            //services.AddDbContext<CategoryDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            //services.AddDbContext<CustomerDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            //services.AddDbContext<OrderDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            //services.AddDbContext<OrderDetailsDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            //services.AddDbContext<PaymentDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            //services.AddDbContext<ProductDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            //services.AddDbContext<StockDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));
            services.AddDbContext<UserDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingDB"]));

            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
