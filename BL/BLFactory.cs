using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BLFactory
    {
        public static IBL bL;
        public static IBL GetIbl()
        { return bL ?? (bL = new Bl_imp()); }
    }
}

