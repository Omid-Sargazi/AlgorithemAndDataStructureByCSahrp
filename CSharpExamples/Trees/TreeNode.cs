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

    public class BinaryTree
    {
        public int Value;
        public BinaryTree Left;
        public BinaryTree Right;

        public BinaryTree(int value)
        {
            Value = value;
        }


        public static void RunTreeNode()
        {
            BinaryTree root = new BinaryTree(0);
            root.Left = new BinaryTree(1);
            root.Right = new BinaryTree(2);

            root.Left.Left = new BinaryTree(3);
            root.Left.Right = new BinaryTree(4);

            root.Right.Left = new BinaryTree(5);
            root.Right.Right = new BinaryTree(6);

            Preorder(root);
        }

        private static void Preorder(BinaryTree node)
        {
            if (node == null) return;
            Console.WriteLine($"{node.Value}" + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }

        public static void Inorder(BinaryTree node)
        {
            if (node == null) return;
            Inorder(node.Left);
            Console.WriteLine($"{node.Value}" + " ");
            Inorder(node.Right);
        }

        public static void Postorder(BinaryTree node)
        {
            if (node == null) return;
            Postorder(node.Left);
            Postorder(node.Right);
            Console.WriteLine($"{node.Value}" + " ");
        }
    }




}