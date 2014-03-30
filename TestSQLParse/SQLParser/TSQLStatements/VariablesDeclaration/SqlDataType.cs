using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLParser.TSQLStatements
{
    class SqlDataType : BaseStatement
    {
        public SqlDataType(XElement element)
            : base(element)
        { }
    }
}
