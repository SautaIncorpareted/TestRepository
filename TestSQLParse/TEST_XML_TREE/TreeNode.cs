using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TEST_XML_TREE
{
    public class TreeNode
    {

        TreeNode Parent
        {
            get;
            set;
        }
        public TreeNode(string content, TreeNode parent)
        {
            Parent = parent;
            Content = content;
        }
        public void AddChildren(TreeNode newChild)
        {
            Children.Add(newChild);
        }
        public ObservableCollection<TreeNode> Children
        {
            get { return children; }
        }
        private ObservableCollection<TreeNode> children = new ObservableCollection<TreeNode>();

        public string Content
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "some";
            //return base.ToString();
        }
    }
}
