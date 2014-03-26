using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SQLParser
{
    public class BaseStatement : AbstractStatement
    {
        
        public BaseStatement(XElement element):base(element)
        {
            
        }
    }
}
