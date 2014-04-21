using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_backaper.FTPTree
{
    public abstract class FTPAbstractTreeNode
    {
        //protected List<string> ignoreList = new List<string>() { ".", ".." };
        public FTPAbstractTreeNode(string name, string globalPath, FTPAbstractTreeNode parent, FTPRootTreeNode rootTreeNode, string localPath)
        {
            Name = name;
            GlobalPath = globalPath;
            Parent = parent;
            Root = rootTreeNode;
            LocalPath = localPath;
        }
        public string LocalPath { get; set; }
        public FTPRootTreeNode Root { get; set; }
        public FTPAbstractTreeNode Parent;
        public string Name { get; set; }
        public string GlobalPath { get; set; }

        protected List<FTPAbstractTreeNode> children = new List<FTPAbstractTreeNode>();
        public virtual List<FTPAbstractTreeNode> Children
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
        public abstract void MapToObject();
        public abstract void MapToLocalMashine();
    }
}
