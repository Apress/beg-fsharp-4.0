using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;

namespace Chapter12CSharp
{
    class CurriedAndTupledClass
    {
        public static void CallCurriedStyle()
        {
            var d = new DemoClass(1);
            var x = d.CurriedStyle(1, 3);
        }

        public static void CallTupleStyle()
        {
            var d = new DemoClass(1);
            var x = d.TupleStyle(1, 3);
        }
    }
}
