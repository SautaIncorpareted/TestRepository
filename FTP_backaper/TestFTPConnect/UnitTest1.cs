using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FTP_Connector;


namespace TestFTPConnect
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FTPConnector connector = new FTPConnector();
            connector.GetFtpPathData("");
        }
    }
}
