using System;
using System.Collections.Generic;
using System.Text;
using SalesTax.Engine;

namespace SalesTax.Engine.UnitTest.MockStubs
{
     class DataSourceTrueMock:IDataSource
    {
        public bool IsProductTaxable(string name)
        {
            return true;
        }
    }
}
