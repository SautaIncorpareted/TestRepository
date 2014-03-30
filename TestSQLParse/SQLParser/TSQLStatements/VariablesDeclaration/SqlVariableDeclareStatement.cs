using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLParser.TSQLStatements
{
    class SqlVariableDeclareStatement : BaseStatement
    {
        public SqlVariableDeclareStatement(XElement element)
            : base(element)
        { }
    }
}
