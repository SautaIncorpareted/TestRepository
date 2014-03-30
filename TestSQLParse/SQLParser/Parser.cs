using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQLParser
{
    public class Parser
    {
        public static string Parse(string parseSourceCode)
        {
            var pOption = new Microsoft.SqlServer.Management.SqlParser.Parser.ParseOptions();
            var msParseResult = Microsoft.SqlServer.Management.SqlParser.Parser.Parser.Parse(parseSourceCode, pOption);
            var all1 = msParseResult.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var parseResult = all1.First().GetValue(msParseResult);
            var refToPropery = parseResult.GetType().GetProperties().First(x => x.Name == "Xml");
            var searchedResult = refToPropery.GetValue(parseResult, null);
            return searchedResult.ToString();
        }
    }
}
