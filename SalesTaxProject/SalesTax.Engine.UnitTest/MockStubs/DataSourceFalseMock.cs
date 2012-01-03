using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine.UnitTest.MockStubs
{
    class DataSourceFalseMock:IDataSource
    {
        public bool IsProductTaxable(string name)
        {
            return false;
        }
    }
}
