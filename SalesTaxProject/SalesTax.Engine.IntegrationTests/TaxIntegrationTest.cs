using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SalesTax.Engine;

namespace SalesTax.Engine.IntegrationTests
{
    [TestFixture]
    public class TaxIntegrationTest
    {        
        [Test]
        public void NonImportedProducts()
        {
        
            ShoppingCart oCart = new ShoppingCart();
            oCart.AddProduct("book", 1, 12.49, false);
            oCart.AddProduct("music cd", 1, 14.99, false);
            oCart.AddProduct("chocolate bar", 1, 0.85, false);
            oCart.CheckOut();

            Assert.NotNull(oCart, "Shopping Cart cannot be null as there are products in it");
            Assert.AreEqual(3, oCart.ProductList.Count, "number of products in shopping cart");

            Assert.AreEqual(1.50, oCart.TotalTax, "Total Charges for all products i.e. sales tax. No import duty added as products are not imported ");
            Assert.AreEqual(29.83, oCart.TotalPriceIncludingTax, "Total Amount for all products ");               

        }

        [Test]
        public void ImportedProducts()
        {               
            ShoppingCart oCart = new ShoppingCart();
             oCart.AddProduct("box of chocolates", 1, 10, true);
             oCart.AddProduct("bottle of perfume", 1, 47.50, true);
             oCart.CheckOut();

            Assert.NotNull(oCart, "Shopping Cart cannot be null as there are products in it");
            Assert.AreEqual(2, oCart.ProductList.Count, "number of products in shopping cart");

            Assert.AreEqual(7.65, oCart.TotalTax, "Total Charges for all products i.e. sales tax and import duty ");
            Assert.AreEqual(65.15, oCart.TotalPriceIncludingTax, "Total Amount for all products ");

        }

        [Test]
        public void GeneralCase()
        {
           
            ShoppingCart oCart = new ShoppingCart();          
            oCart.AddProduct("bottle of perfume", 1, 27.99, true);
            oCart.AddProduct("bottle of perfume", 1, 18.99, false);
             oCart.AddProduct("packet of headache pills", 1, 9.75, false);
             oCart.AddProduct("box of chocolates", 1, 11.25, true);
             oCart.CheckOut();

            Assert.NotNull(oCart, "Shopping Cart cannot be null as there are products in it");
            Assert.AreEqual(4, oCart.ProductList.Count, "number of products in shopping cart");

            Assert.AreEqual(6.7, oCart.TotalTax, "Total Charges for all products i.e. sales tax and import duty ");
            Assert.AreEqual(74.68, oCart.TotalPriceIncludingTax, "Total Amount for all products ");

        }

        [Test]
        public void TaxExemptImportedProducts()
        {
         
            ShoppingCart oCart = new ShoppingCart();
             oCart.AddProduct("box of chocolates", 1, 10, true);
             oCart.AddProduct("book", 1, 12.49, true);
             oCart.AddProduct("packet of headache pills", 1, 9.75, true);
             oCart.CheckOut();

            Assert.NotNull(oCart, "Shopping Cart cannot be null as there are products in it");
            Assert.AreEqual(3, oCart.ProductList.Count, "number of products in shopping cart");

            Assert.AreEqual(1.65, oCart.TotalTax, "chocolates,books and pills belong to food,books and medical category respectively so sales tax is exempted. Only import duty added");
            Assert.AreEqual(33.89, oCart.TotalPriceIncludingTax, "Total Amount for all products ");

        }

        [Test]
        public void TaxExemptNonImportedProducts()
        {
            
            ShoppingCart oCart = new ShoppingCart();
            oCart.AddProduct("chocolate bar", 1, 0.85, false);
            oCart.AddProduct("book", 2, 12.49, false);
            oCart.AddProduct("packet of headache pills", 1, 9.75, false);
            oCart.CheckOut();

            Assert.NotNull(oCart, "Shopping Cart cannot be null as there are products in it");
            Assert.AreEqual(3, oCart.ProductList.Count, "number of products in shopping cart");

            Assert.AreEqual(0, oCart.TotalTax, "chocolates,books and pills belong to food,books and medical category respectively so sales tax is exempted. As all products are not imported no import duty added");
            Assert.AreEqual(35.58, oCart.TotalPriceIncludingTax, "Total Amount for all products");

        }

        [Test]
        public void TaxableImportedProducts()
        {
            
            ShoppingCart oCart = new ShoppingCart();
           oCart.AddProduct("music cd", 2, 14.99, true);
            oCart.AddProduct("bottle of perfume", 2, 47.50, true);
            oCart.CheckOut();

            Assert.NotNull(oCart, "Shopping Cart cannot be null as there are products in it");
            Assert.AreEqual(2, oCart.ProductList.Count, "number of products in shopping cart");

            Assert.AreEqual(18.75, oCart.TotalTax, "products dont belong to food,books and medical category respectively so sales tax is added. As all products are imported so import duty added");
            Assert.AreEqual(143.73, oCart.TotalPriceIncludingTax, "Total Amount for all products verified");

        }

        [Test]
        public void TaxableNonImportedProducts()
        {
          
            ShoppingCart oCart = new ShoppingCart();
            oCart.AddProduct("music cd", 1, 14.99, false);
            oCart.AddProduct("bottle of perfume", 1, 47.50, false);
            oCart.CheckOut();

            Assert.NotNull(oCart, "Shopping Cart cannot be null as there are products in it");
            Assert.AreEqual(2, oCart.ProductList.Count, "number of products in shopping cart");

            Assert.AreEqual(6.25, oCart.TotalTax, "products dont belong to food,books and medical category respectively so sales tax is added. As all products are imported so import duty is added");
            Assert.AreEqual(68.74, oCart.TotalPriceIncludingTax, "Total Amount for all products verified");

        }
       
    }
}
