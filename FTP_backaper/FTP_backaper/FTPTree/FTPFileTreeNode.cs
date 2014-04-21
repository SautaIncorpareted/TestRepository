using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_backaper.FTPTree
{
    public class FTPFileTreeNode : FTPAbstractTreeNode
    {
        public FTPFileTreeNode(string name, string globalPath, FTPAbstractTreeNode parent, FTPRootTreeNode root, string localPath) : base(name, globalPath, parent, root, localPath) { }
        public override void MapToObject()
        {
            //throw new NotImplementedException();
        }

        public override void MapToLocalMashine()
        {
            var filePath = Path.Combine(LocalPath, GlobalPath, Name);
            var directoryPath = Path.GetDirectoryName(filePath);
            var dirParts = directoryPath.Split('/');
            string combinePath = string.Empty;
            dirParts.ToList().ForEach(x =>
            {
                combinePath = Path.Combine(combinePath, x);
                if (!Directory.Exists(combinePath))
                {
                    Directory.CreateDirectory(combinePath);
                }
            });

            File.WriteAllText(filePath, Root.Connection.ReadFile(string.Format("{0}/{1}", GlobalPath, Name)));
        }
    }
}
