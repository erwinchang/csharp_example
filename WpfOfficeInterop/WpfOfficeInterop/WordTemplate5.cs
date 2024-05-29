using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOfficeInterop
{
    public class WordTemplate5
    {
        public static bool Test(ref string strRet)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {

            }
            catch(Exception ex)
            {
                flag = false;
                strRet = string.Format("[Test] {0}", ex.Message);
            }
            return flag;
        }
    }
}
