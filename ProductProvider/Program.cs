
using ProductProvider.Contexts;

using Microsoft.EntityFrameworkCore;
using ProductProvider.Interfaces;
using ProductProvider.Services;
using ProductProvider.Repositories;
namespace ProductProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddCors(o =>
                o.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .WithMethods("PUT")
                    .AllowAnyHeader();
                }));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
