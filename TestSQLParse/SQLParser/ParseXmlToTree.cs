using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SQLParser
{
    public class ParseXmlToTree
    {
        public AbstractStatement Root
        {
            get;
            set;
        }
        public XDocument xmlDocument = new XDocument();
        public void ParseXmlStrToTree(string xmlStr)
        {
            xmlDocument = XDocument.Parse(xmlStr);
            Root = new BaseStatement(xmlDocument.Root);
            RecursiveParse(Root, xmlDocument.Root);
        }
        private void RecursiveParse(AbstractStatement statement, XElement element)
        {
            foreach (var elem in element.Elements())
            {
                var newStatement = new BaseStatement(elem);
                statement.Children.Add(newStatement);
                RecursiveParse(newStatement, elem);
            }

        }
    }
}
