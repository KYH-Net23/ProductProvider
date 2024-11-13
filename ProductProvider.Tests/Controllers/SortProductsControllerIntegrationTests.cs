
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using ProductProvider.Controllers;
using ProductProvider.Interfaces;
using ProductProvider.Models;

namespace ProductProvider.Tests.Controllers;

public class SortProductsControllerIntegrationTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void SetUp()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task GetSortedProducts_ByPriceAscendingSortOrder_ReturnsAscendingOrder()
    {
        // Act
        var response = await _client.GetAsync("/api/sortproducts?sortOption=PriceAscending");

        // Assert
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ProductEntity>>(responseContent);

        // Assert
        Assert.That(products, Is.Ordered.By("Price").Ascending);
    }

    [Test]
    public async Task GetSortedProducts_ByPriceDescendingSortOrder_ReturnsDescendingOrder()
    {
        // Act
        var response = await _client.GetAsync("/api/sortproducts?sortOption=PriceDescending");

        // Assert
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ProductEntity>>(responseContent);

        // Assert
        Assert.That(products, Is.Ordered.By("Price").Descending);
    }

    [Test]
    public async Task GetSortedProducts_ByAlphabeticalSortOrder_ReturnsAlphabeticalOrder()
    {
        // Act
        var response = await _client.GetAsync("/api/sortproducts?sortOption=Alphabetical");

        // Assert
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ProductEntity>>(responseContent);

        // Assert
        Assert.That(products, Is.Ordered.By("Model").Ascending);
    }
    [Test]
    public async Task GetSortedProducts_ByAlphabeticalDescendingSortOrder_ReturnsAlphabeticalDescendingOrder()
    {
        // Act
        var response = await _client.GetAsync("/api/sortproducts?sortOption=AlphabeticalDescending");

        // Assert
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ProductEntity>>(responseContent);

        // Assert
        Assert.That(products, Is.Ordered.By("Model").Descending);
    }
}
