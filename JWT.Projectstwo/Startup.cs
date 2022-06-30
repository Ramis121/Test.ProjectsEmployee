using Domain.Interface;
using JWT.Projectstwo.Data;
using JWT.Projectstwo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace JWT.Projectstwo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEmployees, EmployeesRepository>();
            services.AddDbContext<ApplicationDbContext>(option =>
                    option.UseNpgsql(Configuration.GetConnectionString("BloggingDatabase")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication12", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment hostBuilder)
        {
            if (hostBuilder.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
                application.UseSwagger();
                application.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication12 v1"));
            }

            application.UseHttpsRedirection();

            application.UseRouting();

            application.UseAuthorization();

            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
