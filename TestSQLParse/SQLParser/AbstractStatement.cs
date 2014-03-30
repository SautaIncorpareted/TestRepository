using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SQLParser
{
    public abstract class AbstractStatement
    {
        XElement XmlNodeOfTree;
        public AbstractStatement(XElement element)
        {
            XmlNodeOfTree = element;
            var location = element.Attributes().FirstOrDefault(x => x.Name.ToString() == "Location");
            if (location != null)
            {
                var match = Regex.Match(location.Value, @"\({2}(\d+),(\d+)\),\s*\((\d+),(\d+)", RegexOptions.Compiled);
                LineStart = int.Parse(match.Groups[1].Value);
                PositionStart = int.Parse(match.Groups[2].Value);
                LineEnd = int.Parse(match.Groups[3].Value);
                PositionEnd = int.Parse(match.Groups[4].Value);
                //location.Value
            }
            NameOfStatement = string.Format("{0} : {1} : Line {2}", element.Name.ToString(), this.GetType().Name, LineStart);

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
        public int LineStart
        {
            get;
            set;
        }
        public int PositionStart
        {
            get;
            set;
        }
        public int LineEnd
        {
            get;
            set;
        }
        public int PositionEnd
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
