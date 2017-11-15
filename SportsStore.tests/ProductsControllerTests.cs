using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace SportsStore.tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public void CanPaginate()
        {
            //Arrange           
                Mock<IProductRepository> mockProdRep = new Mock<IProductRepository>();
            mockProdRep.Setup(m => m.Products).Returns(new Product[] {
                    new Product {ProductID = 1, Name = "P1"},
                    new Product {ProductID = 2, Name = "P2"},
                    new Product {ProductID = 3, Name = "P3"},
                    new Product {ProductID = 4, Name = "P4"},
                    new Product {ProductID = 5, Name = "P5"},
                    new Product {ProductID = 6, Name = "P6"},
                    new Product {ProductID = 7, Name = "P7"},
                    new Product {ProductID = 8, Name = "P8"}

                });

            ProductsController controller = new ProductsController(mockProdRep.Object);
            controller.PageSize = 3;

            //Act
            IEnumerable<Product> productsList = (IEnumerable<Product>) controller.List(3).Model ;


            //Assert
            Product[] productsArray = productsList.ToArray();
            Assert.True(productsArray.Length == 2);
            Assert.Equal("P7", productsArray[0].Name);
            Assert.Equal("P8", productsArray[1].Name);

        }
    }
}
