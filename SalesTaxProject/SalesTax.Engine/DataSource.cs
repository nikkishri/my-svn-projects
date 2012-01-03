using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine
{
    public sealed class DataSource:IDataSource
    {
        Dictionary<string, string> diProductEntity;
        Dictionary<string, string> diProductCategory;
        private static DataSource _singletonInstance;
        private static object syncRoot = new Object(); //Adding multithreading support


        private DataSource()
        {
            diProductEntity = new Dictionary<string, string>();
            diProductEntity.Add("BOOK", "EXEMPT");
            diProductEntity.Add("FOOD", "EXEMPT");
            diProductEntity.Add("MEDICAL", "EXEMPT");
            diProductEntity.Add("MISC", "TAXABLE");

            diProductCategory = new Dictionary<string, string>();
            diProductCategory.Add("book", "BOOK");
            diProductCategory.Add("chocolate bar", "FOOD");
            diProductCategory.Add("box of chocolates", "FOOD");
            diProductCategory.Add("packet of headache pills", "MEDICAL");
        }


        public static DataSource GetInstance()
        {
            if (_singletonInstance == null)
            {

                lock (syncRoot)
                {
                    if (_singletonInstance == null)
                        _singletonInstance = new DataSource();

                }
            }
            return _singletonInstance;

        }


        private bool IsCategoryTaxable(string productcategory)           //to find the entity of product category
        {
            string sEntity = string.Empty;

                //get values from datasource
                if (diProductEntity.ContainsKey(productcategory.ToUpper()))
                {
                    if (diProductEntity[productcategory].Equals("EXEMPT"))
                    {
                        return false;
                    }
                }

           return true;
            
           
        }

        public bool IsProductTaxable(string name)             //to find the category which the product belongs to
        {
            string sCategory = string.Empty;
            try
            {
                //get values from datasource
                if (diProductCategory.ContainsKey(name.ToLower()))
                {
                    sCategory = diProductCategory[name];
                }
                else
                {
                    sCategory = "MISC";             //uncategorized items will be categorised as miscellaneous
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger oLogger = new ExceptionLogger();
                oLogger.WriteLog(ex);
            }
            return IsCategoryTaxable(sCategory);
        }

    }
}
