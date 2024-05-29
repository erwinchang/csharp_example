using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOfficeInterop
{
    public class WordTemplate4
    {
        //https://learn.microsoft.com/en-us/office/open-xml/word/structure-of-a-wordprocessingml-document?tabs=cs
        public static bool Test(ref string strRet)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {

            }
            catch(Exception ex)
            {
                flag = true;
                strRet = string.Format("[] {0}", ex.Message);
            }
            return flag;
        }
    }
}
