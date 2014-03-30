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
        public AbstractStatement RootAST
        {
            get;
            set;
        }
        public XDocument xmlDocument = new XDocument();
        public void ParseXmlStrToTree(string xmlStr)
        {
            xmlDocument = XDocument.Parse(xmlStr);
            Root = StatementCreator.ParseNodeToStatement(xmlDocument.Root);// new BaseStatement();
            RecursiveParse(Root, xmlDocument.Root);
            ParserApplication.Parser parser = new ParserApplication.Parser();
            var parsed = parser.StartParse(xmlDocument.Root);

        }
        private void RecursiveParse(AbstractStatement statement, XElement element)
        {
            foreach (var elem in element.Elements())
            {
                var newStatement = StatementCreator.ParseNodeToStatement(elem);
                statement.Children.Add(newStatement);
                RecursiveParse(newStatement, elem);
            }
        }
    }
}
