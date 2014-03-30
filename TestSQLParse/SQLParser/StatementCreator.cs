using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SQLParser.TSQLStatements;

namespace SQLParser
{
    public static class StatementCreator
    {
        public static AbstractStatement ParseNodeToStatement(XElement element)
        {
            AbstractStatement statement = null;
            switch (element.Name.ToString())
            {
                case ("SqlScript"):
                    statement = new SqlScript(element);
                    break;
                case ("Errors"):
                    statement = new Errors(element);
                    break;
                case ("SqlBatch"):
                    statement = new SqlBatch(element);
                    break;
                case ("SqlColumnDefinition"):
                    statement = new SqlColumnDefinition(element);
                    break;
                case ("SqlDataType"):
                    statement = new SqlDataType(element);
                    break;
                case ("SqlDataTypeSpecification"):
                    statement = new SqlDataTypeSpecification(element);
                    break;
                case ("SqlIdentifier"):
                    statement = new SqlIdentifier(element);
                    break;
                case ("SqlInlineTableVariableDeclaration"):
                    statement = new SqlInlineTableVariableDeclaration(element);
                    break;
                case ("SqlInlineTableVariableDeclareStatement"):
                    statement = new SqlInlineTableVariableDeclareStatement(element);
                    break;
                case ("SqlObjectIdentifier"):
                    statement = new SqlObjectIdentifier(element);
                    break;
                case ("SqlTableDefinition"):
                    statement = new SqlTableDefinition(element);
                    break;
                case ("SqlVariableDeclaration"):
                    statement = new SqlVariableDeclaration(element);
                    break;
                case ("SqlVariableDeclareStatement"):
                    statement = new SqlVariableDeclareStatement(element);
                    break;
                default:
                    statement = new UnkownStatement(element);
                    break;
            }
            return statement;
        }
    }
}
