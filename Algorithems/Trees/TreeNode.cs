using System.Linq.Expressions;

namespace Algorithems.Trees
{
    public class TreeNode
    {
        public string Value;
        public List<TreeNode> Children = new List<TreeNode>();
        public TreeNode(string value)
        {
            Value = value;
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
    }

    public class RunTreeNode
    {
        public static void Run()
        {
            var root = new TreeNode("Father");
            var omid = new TreeNode("Omid");
            var saeed = new TreeNode("Saeed");
            var vahid = new TreeNode("Vahid");

            root.AddChild(omid);
            root.AddChild(saeed);
            root.AddChild(vahid);

            var saleh = new TreeNode("Saleh");
            var samyar = new TreeNode("Samyar");
            omid.AddChild(saleh);
            omid.AddChild(samyar);
        }

        private static void PrintTree(TreeNode node, int level = 0)
        {
            Console.WriteLine(new string('-', level * 2) + node.Value);
            foreach (var child in node.Children)
            {
                PrintTree(child, level + 1);
            }
        }
    }
}