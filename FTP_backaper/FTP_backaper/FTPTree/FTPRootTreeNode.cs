using FTP_Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_backaper.FTPTree
{
    public class FTPRootTreeNode : FTPAbstractTreeNode
    {
        public FTPRootTreeNode(string name, string globalPath, FTPAbstractTreeNode parent, FTPConnector conn, string localPath)
            : base(name, globalPath, parent, null, localPath)
        {
            Connection = conn;
            Factory = new FTPTreeFactory();
        }

        public FTPConnector Connection { get; set; }
        public FTPTreeFactory Factory { get; set; }

        public override void MapToObject()
        {
            var configStr = Connection.GetFtpPathData(string.Format("{0}{1}", GlobalPath, string.IsNullOrEmpty(Name) ? "" : "/" + Name));
            var lines = configStr.Split('\n').Where(x => !string.IsNullOrEmpty(x) && !x.Trim().EndsWith(".")).ToList();
            lines.ForEach(x => Children.Add(Factory.GetTreeNode(x, GlobalPath, this, this, LocalPath)));
            Children.Where(x => x is FTPDirectoryTreeNode).ToList().ForEach(x => x.MapToObject());
        }

        public override void MapToLocalMashine()
        {

            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(LocalPath, GlobalPath, Name));
            Children.ForEach(x => x.MapToLocalMashine());
        }
    }
}
