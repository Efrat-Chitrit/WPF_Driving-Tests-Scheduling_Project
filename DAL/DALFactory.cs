using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DALFactory //factory
    {
        private static IDal dl=null;
        public static IDal GetIdal()
        {
            // return dl ?? (dl = Dal_imp.GetDal());//so we can work with datasorce(DS)
            return dl ?? (dl = Dal_XML_imp.GetDal());//so we can work with xml files
        }
    }
}
