using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
  public  class Product
    {
        private String _name;
        private Double _unitPrice;
        private int _quantity;
        private Boolean _imported;
        private Tax _tax;

        public Product(String name, int quantity, Double price, bool imported)
        {

                _name = name;
                _quantity = quantity;
                _unitPrice = price;
                _imported = imported;
           
        }
        public double GetTax()
        {
            if (_tax == null)
            {
                throw new ArgumentNullException("Tax type can not be null");
            }

            return _tax.calculate(_unitPrice) * _quantity;
        }

        public string Name
        {
            get { return _name; }
        }

        public Double Price
        {
            get { return _unitPrice*_quantity; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public bool Imported
        {
            get { return _imported; }
        }
        public Tax Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
    }
}
