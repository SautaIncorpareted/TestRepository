using FTP_backaper.FTPTree;
using FTP_Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;

            FTPConnector connector = new FTPConnector();

            FTPRootTreeNode root = new FTPRootTreeNode("", "docu2/data/pages", connector, @"D:\docu");
            root.MapToObject();
            root.MapToLocalMashine();
            //Console.WriteLine("Time:" + (DateTime.Now - now));

            //Console.ReadKey();
        }
    }
}
