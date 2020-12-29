using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebService.asmx.Classes
{
    public class StringUTF8:System.IO.StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}