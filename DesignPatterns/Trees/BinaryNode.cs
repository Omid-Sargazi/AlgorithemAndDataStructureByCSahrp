namespace DesignPatterns.Trees
{
    public class BinaryNode
    {
        public int Value { get; set; }
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }

        public BinaryNode(int value)
        {
            Value = value;
        }
    }

    public class RunBinaryNode
    {
        public static void Run()
        {
            var root = new BinaryNode(1);
            root.Left = new BinaryNode(2);
            root.Right = new BinaryNode(3);
            root.Left.Left = new BinaryNode(4);
            root.Left.Right = new BinaryNode(5);
            root.Right.Left = new BinaryNode(6);

            Preorder(root);
            Console.WriteLine("Inorder Traversal:");
            Inorder(root);

        }

        private static void Preorder(BinaryNode node)
        {
            if (node == null) return;
            Console.WriteLine(node.Value);
            Preorder(node.Left);
            Preorder(node.Right);
        }

        private static void Inorder(BinaryNode node)
        {
            if (node == null) return;
            Inorder(node.Left);
            Console.WriteLine(node.Value + " ");
            Inorder(node.Right);
        }

        private static void Postorder(BinaryNode node)
        {
            if (node == null) return;
            Postorder(node.Left);
            Postorder(node.Right);
            Console.WriteLine(node.Value + " ");
        }

        private static void LevelOrder(BinaryNode root)
        {
            if (root == null) return;
            var queue = new Queue<BinaryNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                Console.WriteLine(cur.Value + " ");
                if (cur.Left != null) queue.Enqueue(cur.Left);
                if(cur.Right != null) queue.Enqueue(cur.Right);
            }
        }
            
        }
}