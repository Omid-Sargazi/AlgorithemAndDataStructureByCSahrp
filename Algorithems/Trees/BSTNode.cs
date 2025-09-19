namespace Algorithems.Trees
{
    public class BSTNode
    {
        public int Value;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode(int value)
        {
            Value = value;
        }

        public BSTNode Insert(BSTNode root, int value)
        {
            if (root == null) return new BSTNode(value);

            if (value < root.Value)
                root.Left = Insert(root.Left, value);

            else if (value > root.Left)
                root.Right = Insert(root.Right, value);

            return root;
        }

        public bool Search(BSTNode root, int value)
        {
            if (root == null) return false;
            if (root.Value == value) return true;

            if (value < root.Value)
                return Search(root.Left, value);
            else
                return Search(root.Right, value);
        }
    }
}