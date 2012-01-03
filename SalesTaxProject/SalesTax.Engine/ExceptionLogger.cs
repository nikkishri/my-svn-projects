using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SalesTax.Engine
{
    class ExceptionLogger
    {
        

        public ExceptionLogger()
        {
          
        }

        public void WriteLog(Exception exception)
        {
            try
            {
               
                Console.WriteLine("Exception: {0}", exception.Message);
               
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("Exception: {0}", ex.Message);
                
            }
        }
    }
}
