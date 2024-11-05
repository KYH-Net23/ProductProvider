using CreateProducts.Models;

namespace CreateProducts.Interfaces
{
    public interface IProductService
    {
        public void CreateNewProduct(ProductModel model);
    }
}