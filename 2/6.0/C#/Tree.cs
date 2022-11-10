using System;

public class Tree
{
    public Node root;

    public int Size { get; private set; } = 0;

    public Node CreateTree(int[] arr, int i)
    {
        Node root = null;

        if (i < arr.Length)
        {
            root = new Node(arr[i]);

            root.Left = CreateTree(arr, 2 * i + 1);

            root.Right = CreateTree(arr, 2 * i + 2);
        }
        return root;
    }

    public double CountAverage()
    {
        double sum = 0;

        if (root == null)
        {
            return 0;
        }

        Stack<Node> s = new Stack<Node>();
        Node current = root;

        while (current != null || s.Count > 0)
        {

            while (current != null)
            {
                s.Push(current);
                current = current.Left;
            }

            current = s.Pop();

            sum += current.Value;
            Size++;

            current = current.Right;
        }
        return sum / Size;
    }

    private static void printTree(Node root, int space)
    {
        if (root == null)
            return;

        space += 10;

        printTree(root.Right, space);

        Console.Write("\n");
        for (int i = 10; i < space; i++)
            Console.Write(" ");
        Console.Write(root.Value + "\n");

        printTree(root.Left, space);
    }

    public static void Print(Node root)
    {
        printTree(root, 0);
    }
}

public class Node
{
    public Node Left { get; set; } = null;
    public Node Right { get; set; } = null;

    public double Value { get; set; }

    public Node(double value) { Value = value; }
}
