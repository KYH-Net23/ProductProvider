
using Microsoft.EntityFrameworkCore;
using ProductsUpdate.Factories;
using ProductsUpdate.Repositories;
using ProductsUpdate.Services;
using Shared.Contexts;

namespace ProductsUpdate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();
            builder.Services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<ProductRepository>();
            builder.Services.AddTransient<ProductService>();

            builder.Services.AddCors(o =>
            o.AddPolicy("AllowLocalhost5173",
            builder =>
            {
                builder.WithOrigins("http://localhost:5173/")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            //builder.Services.AddCors(o =>
            //o.AddPolicy("AllowAll",
            //builder =>
            //{
            //    builder.AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //}));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowLocalhost5173");
            //app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
