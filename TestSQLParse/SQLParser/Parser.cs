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
        public static string Parse(string parseStr)
        {
            var pOption = new Microsoft.SqlServer.Management.SqlParser.Parser.ParseOptions();
            var some = Microsoft.SqlServer.Management.SqlParser.Parser.Parser.Parse(parseStr, pOption);
            Type type = some.GetType();
            MemberInfo[] members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.GetProperty);
            Console.WriteLine(members.Count());
            var all1 = some.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var parseResult = all1.First().GetValue(some);
            Console.WriteLine(parseResult.GetType().ToString());
            var some11 = parseResult.GetType().GetProperties().First(x => x.Name == "Xml");
            var dd = some11.GetValue(parseResult, null);
            return dd.ToString();
        }   
    }
}
