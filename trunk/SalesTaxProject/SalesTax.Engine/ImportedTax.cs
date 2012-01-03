using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
  public  class ImportedTax:Tax
    {
         

         public override double ENTITY_CHARGE
         {
             get { return .05; }
         }
    }
}
