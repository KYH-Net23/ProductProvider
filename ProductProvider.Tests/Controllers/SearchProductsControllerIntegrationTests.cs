using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProductProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductProvider.Tests.Controllers
{
    public class SearchProductsControllerIntegrationTests
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
            _factory.Dispose();
            _client.Dispose();
        }

        [Test]
        public async Task SearchProducts_ByValidQuery_ReturnsMatchingProduct()
        {
            //Arrange
            var searchQuery = "Adidas";

            //Act
            var response = await _client.GetAsync($"/api/searchproducts?query={searchQuery}");

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent  = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductEntity>>(responseContent);

            Assert.That(products, Is.Not.Empty);
            Assert.That(products.All(p => p.Brand.Contains(searchQuery) || p.Model.Contains(searchQuery)));

        }

        [Test]
        public async Task SearchProducts_EmptyQuery_ReturnsBadREquest()
        {
            //Arrange
            var query = "";

            //Act
            var response = await _client.GetAsync($"/api/searchproducts?query={query}");

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
