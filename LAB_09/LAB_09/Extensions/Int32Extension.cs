using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_09.Extensions
{
    public static class Int32Extension
    {
        public static int ModInverse(this Int32 num, int m)
        {
            return new BigInteger(num.ToString()).ModInverse(new BigInteger(m.ToString())).IntValue;
        }
    }
}
