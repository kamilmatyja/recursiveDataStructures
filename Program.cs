using System;
using RecursiveDataStructuresK81;

public class Program
{
    static void Main()
    {
        callBST();
        callAVL();

        String x = Console.ReadLine();
    }

    static void callBST()
    {
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("\r\nZestaw danych BST: {0}", i + 1);

            BST tree = new BST();

            int randomNumbers = random.Next(3, 100);
            for (int j = 1; j <= randomNumbers; j++)
            {
                int randomKey;
                int randomValue;

                if (i % 8 == 0)
                {
                    randomKey = j + 2;
                    randomValue = j + 5;
                }
                else if (i % 9 == 0)
                {
                    randomKey = randomNumbers - j + 3;
                    randomValue = randomNumbers - j + 6;
                }
                else
                {
                    randomKey = random.Next(1, 100);
                    randomValue = random.Next(1, 100);
                }

                DateTime start = DateTime.Now;
                tree.Insert(randomKey, randomValue);
                DateTime end = DateTime.Now;
                TimeSpan ts = (end - start);
                Console.WriteLine("{0}. Czas wykonania dodawania: {1}, klucz: {2}, zawartośś {3}", j, ts.TotalMilliseconds, randomKey, randomValue);
            }

            for (int j = 1; j <= 10; j++)
            {
                int randomSearchKey = random.Next(1, 100);

                DateTime start = DateTime.Now;
                NodeBST node = tree.Search(randomSearchKey, tree.root);
                DateTime end = DateTime.Now;
                TimeSpan ts = (end - start);
                Console.WriteLine("{0}. Czas wykonania znajdowania: {1}, klucz: {2}", j, ts.TotalMilliseconds, randomSearchKey);
                if (node != null)
                {
                    Console.Write(node.Value);
                }
            }

            for (int j = 1; j <= 10; j++)
            {
                int randomRemoveKey = random.Next(1, 100);

                DateTime start = DateTime.Now;
                tree.Remove(randomRemoveKey);
                DateTime end = DateTime.Now;
                TimeSpan ts = (end - start);
                Console.WriteLine("{0}. Czas wykonania usuwania: {1}, klucz: {2}", j, ts.TotalMilliseconds, randomRemoveKey);
            }
        }
    }

    static void callAVL()
    {
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("\r\nZestaw danych AVL: {0}", i + 1);

            AVL tree = new AVL();

            int randomNumbers = random.Next(3, 100);
            for (int j = 1; j <= randomNumbers; j++)
            {
                int randomKey;
                int randomValue;

                if (i % 8 == 0)
                {
                    randomKey = j + 2;
                    randomValue = j + 5;
                }
                else if (i % 9 == 0)
                {
                    randomKey = randomNumbers - j + 3;
                    randomValue = randomNumbers - j + 6;
                }
                else
                {
                    randomKey = random.Next(1, 100);
                    randomValue = random.Next(1, 100);
                }

                DateTime start = DateTime.Now;
                tree.Insert(randomKey, randomValue);
                DateTime end = DateTime.Now;
                TimeSpan ts = (end - start);
                Console.WriteLine("{0}. Czas wykonania dodawania: {1}, klucz: {2}, zawartośś {3}", j, ts.TotalMilliseconds, randomKey, randomValue);
            }

            for (int j = 1; j <= 10; j++)
            {
                int randomSearchKey = random.Next(1, 100);

                DateTime start = DateTime.Now;
                NodeAVL node = tree.Search(randomSearchKey, tree.root);
                DateTime end = DateTime.Now;
                TimeSpan ts = (end - start);
                Console.WriteLine("{0}. Czas wykonania znajdowania: {1}, klucz: {2}", j, ts.TotalMilliseconds, randomSearchKey);
                if (node != null)
                {
                    Console.Write(node.Value);
                }
            }

            for (int j = 1; j <= 10; j++)
            {
                int randomRemoveKey = random.Next(1, 100);

                DateTime start = DateTime.Now;
                tree.Remove(randomRemoveKey);
                DateTime end = DateTime.Now;
                TimeSpan ts = (end - start);
                Console.WriteLine("{0}. Czas wykonania usuwania: {1}, klucz: {2}", j, ts.TotalMilliseconds, randomRemoveKey);
            }
        }
    }
}