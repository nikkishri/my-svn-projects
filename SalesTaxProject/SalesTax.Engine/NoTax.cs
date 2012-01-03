using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
  public  class NoTax:Tax
    {
         


         public override double ENTITY_CHARGE
         {
             get
             {
                 return 0;
             }

         }
    }
}
