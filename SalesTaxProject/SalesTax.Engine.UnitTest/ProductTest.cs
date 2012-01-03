using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SalesTax.Engine.UnitTest.MockStubs;
namespace SalesTax.Engine.UnitTest
{
    [TestFixture]
    public class ProductTest
    {

        [Test]
        public void SalesTaxForDifferentProductsTest()
        {
            Product prod1 = new Product("", 0, 12.49, true);
            Product prod2 = new Product("", 0, 12.49, false);
            prod1.Tax = new MockTax();
            prod2.Tax = new MockTax();
            Assert.AreEqual(prod1.GetTax(), prod2.GetTax());

        }
        [Test]
        public void ProductObjectandMockTaxTest()
        {
            Product prod = new Product("Product", 5, 12.49, true);
            prod.Tax = new MockTax();
            Assert.AreEqual("Product",prod.Name);
            Assert.AreEqual(5, prod.Quantity);
            Assert.AreEqual(12.49 * 5, prod.Price);
            Assert.True(prod.Imported);
            Assert.AreEqual(12.49*.1*5, prod.GetTax());

        }
        [Test]       
        public void NullTaxTest()
        {
            Product prod = new Product("", 0, 12.49, true);
            try
            {
                prod.GetTax();
                Assert.Fail("Product without tax should fail");
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(ArgumentNullException));
            }

        }

    }
}
