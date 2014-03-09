using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.SqlParser;
using System.Reflection;


namespace TestSQLParse
{
    class Program
    {
        static void Main(string[] args)
        {
            var testStr = "SELECT * FROM tbAudit where 1 = 1";
            var pOption = new Microsoft.SqlServer.Management.SqlParser.Parser.ParseOptions();
            var some = Microsoft.SqlServer.Management.SqlParser.Parser.Parser.Parse(testStr, pOption);
            Console.WriteLine(some);
           
            Type type = some.GetType();
            MemberInfo[] members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.GetProperty );
            Console.WriteLine(members.Count());
            var all1 = some.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var parseResult = all1.First().GetValue(some);
            Console.WriteLine(parseResult.GetType().ToString());
            var some11 = parseResult.GetType().GetProperties().First(x => x.Name == "Xml");
            var dd = some11.GetValue(parseResult, null);
            Console.ReadKey();

        }
        internal static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.NonPublic
                ;
            
            FieldInfo field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }
    }
}
