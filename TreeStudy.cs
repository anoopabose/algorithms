public class TreeStud
{

    public class Tree
    {
        public int Data;
        public Tree Left;
        public Tree Right;

        public Tree(int data)
        {
            this.Data = data;
        }
    }

    public Tree Insert(Tree root, int data)
    {
        if (root == null)
        {
            return new Tree(data);
        }
        if (data < root.Data)
        {
            root.Left = Insert(root.Left, data);
        }
        else
        {
            root.Right = Insert(root.Right, data);
        }
        return root;
    }

    public void PrintTree(Tree root)
    {
        if (root == null)
        {
            return;
        }
        PrintTree(root.Left);
        Console.Write(root.Data + " ");
        PrintTree(root.Right);
    }

    public void PrintTreeInOrder(Tree root)
    {
        if (root == null)
        {
            return;
        }
        PrintTreeInOrder(root.Left);
        Console.Write(root.Data + " ");
        PrintTreeInOrder(root.Right);
    }

    public void PrintTreePreOrder(Tree root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.Data + " ");
        PrintTreePreOrder(root.Left);
        PrintTreePreOrder(root.Right);
    }

    public void PrintTreePostOrder(Tree root)
    {
        if (root == null)
        {
            return;
        }
        PrintTreePostOrder(root.Left);
        PrintTreePostOrder(root.Right);
        Console.Write(root.Data + " ");
    }

}