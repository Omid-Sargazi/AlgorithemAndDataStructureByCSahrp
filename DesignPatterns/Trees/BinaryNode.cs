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

            }

            private static void Preorder(BinaryNode node)
            {
                if(node==null) return;
                Console.WriteLine(node.Value);
                Preorder(node.Left);
                Preorder(node.Right);
            }
        }
}