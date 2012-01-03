using System;

namespace SalesTax.Engine
{
  public  class Helper
    {
        static double  ROUND_TO = 0.05;
        public static double RoundOff(double val)
        {
        return Math.Ceiling(val / ROUND_TO) * ROUND_TO;
            //return Math.Round(val, 1, MidpointRounding.AwayFromZero);
        }
    }
}
