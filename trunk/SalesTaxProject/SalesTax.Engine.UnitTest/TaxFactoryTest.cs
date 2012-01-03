using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SalesTax.Engine.UnitTest.MockStubs;

namespace SalesTax.Engine.UnitTest
{
     [TestFixture]
    public class TaxFactoryTest
    {
         [Test]
         public void ProductTaxedandImportedTest()
         {
             TaxFactory taxfactory = new TaxFactory(new DataSourceTrueMock());
             Product prod = new Product("", 0, 0, true);
             Assert.IsInstanceOf(typeof(BasicAndImportedTax), taxfactory.GetTaxType(prod));
         }
         [Test]
         public void ProductTaxedandNotImportedTest()
         {
             TaxFactory taxfactory = new TaxFactory(new DataSourceTrueMock());
             Product prod = new Product("", 0, 0, false);
             Assert.IsInstanceOf(typeof(BasicSalesTax), taxfactory.GetTaxType(prod));
         }
         [Test]
         public void ProductNotTaxedandImportedTest()
         {
             TaxFactory taxfactory = new TaxFactory(new DataSourceFalseMock());
             Product prod = new Product("", 0, 0, true);
             Assert.IsInstanceOf(typeof(ImportedTax), taxfactory.GetTaxType(prod));
         }
         [Test]
         public void ProductNotTaxedandNotImportedTest()
         {
             TaxFactory taxfactory = new TaxFactory(new DataSourceFalseMock());
             Product prod = new Product("", 0, 0, false);
             Assert.IsInstanceOf(typeof(NoTax), taxfactory.GetTaxType(prod));
         }

    }
}
