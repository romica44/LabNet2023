using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Practica3.EF.Entities;
using Practica3.EF.Logic;

namespace UnitTestProjectEF.Tests
{
    [TestClass]
    public class ProductsLogicTests
    {
        [TestMethod]
        public void TestAgregarProducto()
        {
            // Arrange
            Mock<IProductsRepository> mockProductsRepository = new Mock<IProductsRepository>();

            var newProduct = new Products
            {
                ProductName = "Test Product",
                UnitPrice = 10999
            };

            mockProductsRepository.Setup(repo => repo.Add(newProduct)).Verifiable();

            ProductsLogic productsLogic = new ProductsLogic(mockProductsRepository.Object);

            // Act
            productsLogic.Add(newProduct);

            // Assert
            mockProductsRepository.Verify();
        }
    }

    // Definición de la interfaz de acceso a datos
    public interface IProductsRepository
    {
        void Add(Products product);
   
    }

    // Implementación simulada del repositorio de productos
    public class MockProductsRepository : IProductsRepository
    {
        private List<Products> _products = new List<Products>();

        public void Add(Products product)
        {
            _products.Add(product);
        }
    }
}