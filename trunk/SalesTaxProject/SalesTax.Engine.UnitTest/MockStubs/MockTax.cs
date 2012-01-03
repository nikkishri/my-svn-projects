using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Engine.UnitTest.MockStubs
{
    class MockTax:Tax
    {
        public override double ENTITY_CHARGE
        {
            get
            {
                return .1;
            }

        }
    }
}
