using Application.InterfacesRepository;
using Application.UseCases.product;
using Domain.Entities;
using Domain.Events;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductManagement
{
    public class ProductManagementTest
    {
        [Fact]
        public async void TestCreateNormalProductAsync()
        {

            //Given
            IProduct generalProduct = new ProductDomain()
            {
                Name = "Mike",
                Description = "Description",
                Category = "Category",
                Price = 2000,
                Stock = 21
            };


            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.GetProductByName(generalProduct.Name, 0,0)).ReturnsAsync(value: null);
            productRepository.Setup(x => x.Create(generalProduct)).ReturnsAsync(true);
            Product product = new Product(productRepository.Object);


            //When
            var resultInsert = await product.CreateProduct(generalProduct);

            //Then
            Assert.True(resultInsert);
            productRepository.Verify(x => x.Create(generalProduct));
        }

        [Fact]
        public async void TestCreateFailProductAsync()
        {

            //Given
            IProduct generalProduct = new ProductDomain()
            {
                Name = "Mike",
                Description = "Description",
                Category = "Category",
                Price = 2000,
                Stock = 21
            };


            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.Create(generalProduct)).ReturnsAsync(false);
            Product product = new Product(productRepository.Object);


            //When
            var resultInsert = await product.CreateProduct(generalProduct);

            //Then
            Assert.False(resultInsert);
            productRepository.Verify(x => x.Create(generalProduct));
        }

        [Fact]
        public async Task TestGetProductByName()
        {
            //Given
            IProduct generalProduct = new ProductDomain()
            {
                Name = "Mike",
                Description = "Description",
                Category = "Category",
                Price = 2000,
                Stock = 21
            };

            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.GetProductByName("Mike",0,0)).ReturnsAsync(generalProduct);

            Product product = new Product(productRepository.Object);

            //When
            var resultGet = await product.GetProduct("Mike", 0,0);

            //Then 
            Assert.Equal(generalProduct, resultGet);

        }
    }
}
