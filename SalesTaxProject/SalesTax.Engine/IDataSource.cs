using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
   public interface IDataSource
    {
         bool IsProductTaxable(string name);

    }
}
