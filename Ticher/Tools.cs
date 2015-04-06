using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticher
{
    static class Tools
    {
        static public int aRaund(double num)
        {
            decimal degry = Math.Truncate((decimal)Math.Log10(num));

            int pow = 1;
            while (degry > 1)
            {
                pow *= 10;
                degry--;
            }

           double araund = Math.Round(num/(double)pow)*(double)pow;

           return (int)Math.Truncate(araund);

        }
    }
}
