using Microsoft.EntityFrameworkCore;
using ProductsDelete.Data;
using ProductsDelete.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with the connection string from configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register IProductService and its implementation (assuming you have ProductService as the implementation)
builder.Services.AddScoped<IProductService, ProductService>();

// Register DataInitializer service (if needed for seeding data)
builder.Services.AddTransient<DataInitializer>();

// Enable CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware setup
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
