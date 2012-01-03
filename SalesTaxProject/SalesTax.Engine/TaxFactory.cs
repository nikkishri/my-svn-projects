using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
   public class TaxFactory
    {

        private IDataSource _ds = null;

        public TaxFactory(IDataSource ds)
        {
            _ds = ds;
        }

        public  Tax GetTaxType(Product product)
        {
            if (_ds.IsProductTaxable(product.Name))
            {
                if (product.Imported)
                {
                    return new BasicAndImportedTax();
                }
                else
                {
                    return new BasicSalesTax();
                }
            }
            else
            {
                if (product.Imported)
                {
                    return new ImportedTax();
                }
                else
                {
                 return new NoTax();
                }
            }
        }
    }
}
