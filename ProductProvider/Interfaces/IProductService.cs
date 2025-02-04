﻿using ProductProvider.Enums;
using ProductProvider.Models;

namespace ProductProvider.Interfaces
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(ProductModel model, ProductCategory category);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductEntity?> GetProductAsync(int id);
        Task<List<ProductEntity>> GetAllProductsAsync();
        Task<int> UpdateProductAsync(int id, ProductModel model);
        Task<List<ProductEntity>> ProductSearchAsync(string search);
        Task<List<ProductEntity>> SortProductsAsync(SortOption sortOption);
        Task<List<ProductEntity>> GetPaginatedProductsAsync(int page, int limit);
    }
}