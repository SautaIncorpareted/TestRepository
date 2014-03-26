using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SQLParser
{
    public abstract class AbstractStatement
    {
        public AbstractStatement(XElement element)
        {
            if (element == null)
            {
                return;
            }
            NameOfStatement = element.Name.ToString();
        }
        public string NameOfStatement
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
        public int Line
        {
            get;
            set;
        }
        public int Position
        {
            get;
            set;
        }
        private List<AbstractStatement> children = new List<AbstractStatement>();
        public List<AbstractStatement> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }
    }
}
