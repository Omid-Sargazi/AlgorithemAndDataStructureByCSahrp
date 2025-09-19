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

        public void Inorder(BSTNode root)
        {
            if (root == null) return;
            Inorder(root.Left);
            Console.Write(root.Value + " ");
            Inorder(root.Right);
        }

        public BSTNode Delete(BSTNode root, int value)
        {
            if (root == null) return root;

            if (value < root.Value)
                root.Left = Delete(root.Left, value);
            else if (value > root.Value)
                root.Right = Delete(root.Right, value);

            else
            {
                if (root.Left == null) return root.Right;
                else if (root.Right == null) return root.Left;

                // حالت 3: دو فرزند
                root.Value = MinValue(root.Right);
                root.Right = Delete(root.Right, root.Value);
            }

            return root;
        }
    }
}