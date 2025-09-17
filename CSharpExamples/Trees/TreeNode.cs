namespace CSharpExamples.Trees
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


        public static void RunTreeNode()
        {
            TreeNode root = new TreeNode("Father");
            TreeNode omid = new TreeNode("Omid");
            TreeNode saeed = new TreeNode("Saeed");
            TreeNode vahid = new TreeNode("Vahid");
            root.AddChild(omid);
            root.AddChild(saeed);
            root.AddChild(vahid);
            TreeNode saleh = new TreeNode("Saleh");
            TreeNode samyar = new TreeNode("Samyar");

            omid.AddChild(saleh);
            omid.AddChild(samyar);
        }

        public static void PrintTree(TreeNode root, int level = 0)
        {
            Console.WriteLine(new string('-', level) + root.Value);
            foreach (var child in root.Children)
            {
                PrintTree(child, level + 1);
            }
        }
    }


}