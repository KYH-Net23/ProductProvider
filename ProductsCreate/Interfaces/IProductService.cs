using ProductsCreate;

namespace CreateProducts.Interfaces
{
    public interface IProductService
    {
        public Task<string> CreateNewProduct(ProductModel model);
    }
}