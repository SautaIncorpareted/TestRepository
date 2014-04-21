using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_backaper.FTPTree
{
    public class FTPDirectoryTreeNode : FTPAbstractTreeNode
    {
        public FTPDirectoryTreeNode(string name, string globalPath, FTPAbstractTreeNode parent, FTPRootTreeNode root, string localPath) : base(name, globalPath, parent, root, localPath) { }

        public override void MapToObject()
        {
            var configStr = Root.Connection.GetFtpPathData(string.Format("{0}/{1}", GlobalPath, Name));
            var lines = configStr.Split('\n').Where(x => !string.IsNullOrEmpty(x) && !x.Trim().EndsWith(".")).ToList();
            lines.ForEach(x => Children.Add(Root.Factory.GetTreeNode(x, string.Format("{0}/{1}", GlobalPath, Name), this, Root, LocalPath)));
            Children.Where(x => x is FTPDirectoryTreeNode).ToList().ForEach(x => x.MapToObject());
        }

        public override void MapToLocalMashine()
        {
            Directory.CreateDirectory(Path.Combine(LocalPath, GlobalPath, Name));
            Children.ForEach(x => x.MapToLocalMashine());
        }
    }
}
