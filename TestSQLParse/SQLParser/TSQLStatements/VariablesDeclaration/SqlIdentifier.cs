﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLParser.TSQLStatements
{
    class SqlIdentifier : BaseStatement
    {
        public SqlIdentifier(XElement element)
            : base(element)
        { }
    }
}
