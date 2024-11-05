namespace ProductsUpdate.Services
{
    //public class ProductService : IProductUpdateService
    //{
    //    private readonly IProductRepository _productRepo;
    //    private readonly IProductFactory _productFactory;

    //    public ProductService(IProductRepository productRepo, IProductFactory productFactory)
    //    {
    //        _productRepo = productRepo;
    //        _productFactory = productFactory;
    //    }

    //    public async Task UpdateProductAsync(int id, ProductModel model)
    //    {
    //        var existingProductEntity = await _productRepo.GetOneAsync(id);

    //        if (existingProductEntity == null)
    //        {
    //            Console.WriteLine("Product not found");
    //            return;
    //        }

    //        var updatedProductEntity = _productFactory.Create(model);

    //        updatedProductEntity.Id = existingProductEntity.Id;

    //        try
    //        {
    //            await _productRepo.SaveAsync(updatedProductEntity);
    //            Console.WriteLine("Product updated successfully");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error updating product: {ex.Message}");
    //        }
    //    }
    //}
}
