﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUi {
    class Program {
        static void Main(string[] args) {
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest() {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll()) {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest() {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductsDetails();
            if (result.Success) {
                foreach (var product in result.Data) {
                    Console.WriteLine("{0} / {1} ({2})", product.CategoryName, product.ProductName, product.UnitsInStock);
                }
            } else {
                Console.WriteLine(result.Message);
            }
        }
    }
}
