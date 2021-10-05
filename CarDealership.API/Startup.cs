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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            // register services
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAdService, AdService>();
            services.AddScoped<ISellerService, SellerService>();

            // register repositories
            services.AddScoped<IRepository<Car>, Repository<Car>>();
            services.AddScoped<IRepository<Ad>, Repository<Ad>>();
            services.AddScoped<IRepository<Seller>, Repository<Seller>>();
            services.AddScoped<IRepository<Discount>, Repository<Discount>>();
            services.AddScoped<IAdRepository, AdRepository>();

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
        }
    }
}
