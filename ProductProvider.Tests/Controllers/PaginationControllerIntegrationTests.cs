using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProductProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProvider.Tests.Controllers
{
    public class PaginationControllerIntegrationTests
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
        public async Task GetPaginatedProducts_ValidPageAndLimit_ReturnsCorrectProducts()
        {
            //Arrange
            var pageNumber = 1;
            var pageSize = 10;

            //Act
            var response = await _client.GetAsync($"/api/getpagination?page={pageNumber}&limit={pageSize}");

            //Assert
            response.EnsureSuccessStatusCode();

            var responsContent = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductEntity>>(responsContent);

            Assert.That(products, Is.Not.Null);
            Assert.That(products.Count, Is.EqualTo(pageSize));
        }


        [Test]
        public async Task GetPaginatedProducts_WithExceedingPageNumber_ReturnsEmptyList() 
        {
            //Arrange
            var pageNumber = 10;
            var pageSize = 10;

            //Act
            var response = await _client.GetAsync($"/api/getpagination?page={pageNumber}&limit={pageSize}");

            //Assert
            response.EnsureSuccessStatusCode();

            var responsContent = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductEntity>>(responsContent);

            Assert.That(products, Is.Empty);
        }
    }
}
