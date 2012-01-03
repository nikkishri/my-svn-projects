using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
    public abstract class Tax
    {
        abstract  public  double ENTITY_CHARGE {get;}
    
          public double calculate(double price)
         {
             return ENTITY_CHARGE * price;
         }
    }
}
