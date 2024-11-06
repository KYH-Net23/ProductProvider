using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<ProductEntity> productList = [
    new ProductEntity
    {
        Id = 0,
        Brand = "Aloha T-shirt",
        Price = 420m,
        Image = "https://cdn.sanity.io/images/u8zg7cll/production/f6ac780b53f53742b19224aa2e38b592c3365901-2500x2500.svg",
    },
    new ProductEntity
    {
        Id = 1,
        Brand = "Aloha Hot pants",
        Price = 69m,
        Image = "https://cdn.sanity.io/images/u8zg7cll/production/f6ac780b53f53742b19224aa2e38b592c3365901-2500x2500.svg",
    },
    new ProductEntity
    {
        Id = 2,
        Brand = "Aloha String Bikini",
        Price = 9001m,
        Image = "https://cdn.sanity.io/images/u8zg7cll/production/f6ac780b53f53742b19224aa2e38b592c3365901-2500x2500.svg",
    },
    new ProductEntity
    {
        Id = 3,
        Brand = "Aloha Mankini",
        Price = 1234m,
        Image = "https://cdn.sanity.io/images/u8zg7cll/production/f6ac780b53f53742b19224aa2e38b592c3365901-2500x2500.svg",
    },
  ];

app.MapGet("/Products", () =>
{
    return productList;
})
.WithName("GetAll")
.WithOpenApi();

app.Run();
