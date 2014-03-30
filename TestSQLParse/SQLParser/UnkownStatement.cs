using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLParser
{
    class UnkownStatement : BaseStatement
    {
        public UnkownStatement(XElement element)
            : base(element)
        { }
    }
}
