using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SalesTax.Engine;

namespace SalesTax.Engine.UnitTest
{
[TestFixture]
   public class HelperTest
    {
[Test]
        public void RoundOfftoNearest2DecimalPlacesTest()
        {
            Assert.AreEqual(1.80,Helper.RoundOff(1.7658798798798797));
        }
    }
}
