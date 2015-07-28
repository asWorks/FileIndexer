using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tools
    {
        public static bool DateTimeIsEqual(DateTime d1,DateTime d2)
        {
            TimeSpan ts = d1 - d2;
            return !(Math.Abs(ts.Milliseconds) > 10);

        }
    }
}
