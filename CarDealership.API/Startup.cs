using System.Text.Json.Serialization;
using CarDealership.Business.Implementations;
using CarDealership.Business.Interfaces;
using CarDealership.Model.Entities;
using CarDealership.Repositories;
using CarDealership.Repositories.Implementations;
using CarDealership.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using CarDealership.API.Common.Response;


namespace CarDealership.API
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
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;
            services.AddAutoMapper(typeof(Startup));

            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CarDealership API", Version = "v1" });
            });

            services.AddScoped<IResponseStatus, ResponseStatus>();

            // register services
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAdService, AdService>();
            services.AddScoped<ISellerService, SellerService>();

            services.AddScoped<ITypeConverter<int, Car>, TypeConverter<Car>>();
            services.AddScoped<ITypeConverter<int, Seller>, TypeConverter<Seller>>();
            services.AddScoped<ITypeConverter<int, Ad>, TypeConverter<Ad>>();
            services.AddScoped<ITypeConverter<int, Discount>, TypeConverter<Discount>>();

            // register repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // register dbContext
            services.AddScoped<DbContext, ApplicationContext>();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

     
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve geberated Swagger as JSON endpoint.
            app.UseSwagger();

            //Enable middleware to serve swagger-ui specifying the Swagger JSON endpoint
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarDealership API");
           });
            
        }
    }
}
