using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
    public class ShoppingCart
    {

        private List<Product> _productlist;
        private Decimal _totaltax;
        private Decimal _totalPriceIncludingTax;

        public ShoppingCart()
        {
            _productlist = new List<Product>();
        }

        public void AddProduct(string name, int quantity, Double price, bool imported)
        {

            // validation logic would be required if input is coming from user
            
             Product prod = new Product(name, quantity, price, imported);
             TaxFactory taxFactory = new TaxFactory(DataSource.GetInstance());
             Tax tax = taxFactory.GetTaxType(prod);
             prod.Tax = tax;
            _productlist.Add(prod);          
        }

        public List<Product> ProductList
        {
            get { return _productlist; }
            set { _productlist = value; }
        }

        public Decimal TotalTax
        {
            get { return _totaltax; }
            set { _totaltax = value; }
        }

        public Decimal TotalPriceIncludingTax
        {
            get { return _totalPriceIncludingTax; }
            set { _totalPriceIncludingTax = value; }
        }

  
        public void CheckOut()
        {
            double dTotalCharges = 0;
            double dTotal = 0; 
            try
            {
                foreach (Product item in ProductList)           //compute shopcart total and total charges
                {
                    dTotalCharges += item.GetTax();
                    dTotal += item.Price;
                }

                TotalTax = Convert.ToDecimal(Helper.RoundOff(dTotalCharges));
                TotalPriceIncludingTax = Convert.ToDecimal(dTotal )+ TotalTax;

            }
            catch (Exception ex)
            {
                ExceptionLogger oLogger = new ExceptionLogger();
                oLogger.WriteLog(ex);
            }
        }
    }
}
