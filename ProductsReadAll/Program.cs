using Microsoft.EntityFrameworkCore;
using ProductsReadAll.Data;
using ProductsReadAll.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Products", async (ProductDbContext dbContext) =>
{
    var products = await dbContext.Products.ToListAsync();
    return ProductViewModelFactory.GetProducts(products);
})
.WithName("GetAll")
.WithOpenApi();

app.Run();