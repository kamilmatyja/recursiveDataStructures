using RecursiveDataStructuresK81;
using System.Xml.Linq;

public class Program
{
    static void Main()
    {
        callBST();
        callAVL();
    }

    static void callBST()
    {
        Console.WriteLine();
        Console.WriteLine("BST");

        BST tree = new BST();

        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);

        Console.WriteLine("Inorder: ");
        tree.Traverse(tree.root);
        Console.WriteLine();

        Console.WriteLine("Znajdowanie elementu z kluczem 60: ");
        NodeBST node = tree.Search(60);
        if (node != null)
            Console.WriteLine("Znaleziono: " + node.key);
        else
            Console.WriteLine("404");

        Console.WriteLine("Usuwanie elementu z kluczem 30:");
        tree.Delete(30);

        Console.WriteLine("Inorder: ");
        tree.Traverse(tree.root);
        Console.WriteLine();
    }

    static void callAVL()
    {
        Console.WriteLine();
        Console.WriteLine("AVL");

        AVL tree = new AVL();

        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);

        Console.WriteLine("Inorder: ");
        tree.Traverse(tree.root);
        Console.WriteLine();

        Console.WriteLine("Znajdowanie elementu z kluczem 60: ");
        NodeAVL node = tree.Search(60);
        if (node != null)
            Console.WriteLine("Znaleziono: " + node.key);
        else
            Console.WriteLine("404");

        Console.WriteLine("Usuwanie elementu z kluczem 30:");
        tree.Delete(30);

        Console.WriteLine("Inorder: ");
        tree.Traverse(tree.root);
        Console.WriteLine();
    }
}