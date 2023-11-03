﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using SportStore.Controllers;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace SportStore.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Can_Use_Repository()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"}
            }).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);
            // Act
            IEnumerable<Product>? result = (controller.Index(1) as ViewResult)?.ViewData.Model as IEnumerable<Product>; 
            // Assert
            Product[] prodArray = result?.ToArray() ?? Array.Empty<Product>();
            Assert.True(prodArray.Length == 2); 
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }
        [Fact]
        public void Can_Paginate()
        { 
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>(); 
            mock.Setup(m => m.Products).Returns((new Product[] { 
                new Product { ProductId = 1, Name = "P1" }, 
                new Product { ProductId = 2, Name = "P2"},
                new Product { ProductId = 3, Name = "P3" }, 
                new Product { ProductId = 4, Name = "P4" }, 
                new Product { ProductId = 5, Name = "P5" } }).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);
            controller.pageSize = 3;
            // Act
            IEnumerable<Product> result = (controller.Index(2) as ViewResult)?.ViewData.Model as IEnumerable<Product> ?? Enumerable.Empty<Product>(); 
            // Assert
            Product[] prodArray = result.ToArray(); 
            Assert.True(prodArray.Length == 2); 
            Assert.Equal("P4", prodArray[0].Name); 
            Assert.Equal("P5", prodArray[1].Name); }
        }
}
