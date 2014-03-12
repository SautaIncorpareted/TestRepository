using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMCore.ViewModels;
using System.Xml;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace TEST_XML_TREE
{
    class MainWndViewModel : BaseViewModel
    {
        public ObservableCollection<TreeNode> Children
        {
            get { return nodes; }
        }
        ObservableCollection<TreeNode> nodes = new ObservableCollection<TreeNode>();
        public MainWndViewModel()
        {
            var parseRs = SQLParser.Parser.Parse("SELECT * FROM tbAudit");
            XDocument doc = XDocument.Parse(parseRs);

            TreeNode node = new TreeNode("root", null, null);
            nodes.Add(node);
            nodes.Add(node);
            foreach (var elem in doc.Elements())
            {

                TreeNode nodeNew = new TreeNode(elem.Name.LocalName, node,elem);
                node.AddChildren(nodeNew);
                RecusiveParse(elem, nodeNew);
            }
        }
        private void RecusiveParse(XElement elems, TreeNode curNode)
        {
            foreach (var elem in elems.Elements())
            {
                TreeNode nodeNew = new TreeNode(elem.Name.LocalName, curNode, elem);
                curNode.AddChildren(nodeNew);
                RecusiveParse(elem, nodeNew);
            }
        }
        private object selected;
        public object Selected
        {
            get
            { 
                return selected;
            }
            set 
            { 
                selected = value;
            }
        }

    }

}
