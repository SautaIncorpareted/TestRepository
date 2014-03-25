using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DCA
{
    public class TreeNode
    {

        TreeNode Parent
        {
            get;
            set;
        }
        public XElement element
        {
            get;
            set;
        }
        public TreeNode(string content, TreeNode parent, XElement el)
        {
            Parent = parent;
            Content = content;
            element = el;
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
