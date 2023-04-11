using System;
using RecursiveDataStructuresK81;

public class Program
{
    static void Main()
    {
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine();

            Console.WriteLine("Zestaw danych: {0}", i + 1);

            BST treeBST = new BST();
            AVL treeAVL = new AVL();

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

                DateTime start1 = DateTime.Now;
                treeBST.Insert(randomKey, randomValue);
                DateTime end1 = DateTime.Now;
                TimeSpan ts1 = (end1 - start1);
                Console.WriteLine("{0}. Czas wykonania dodawania BST: {1}, klucz: {2}, zawartośś {3}", j, ts1.TotalMilliseconds, randomKey, randomValue);

                DateTime start2 = DateTime.Now;
                treeAVL.Insert(randomKey, randomValue);
                DateTime end2 = DateTime.Now;
                TimeSpan ts2 = (end2 - start2);
                Console.WriteLine("{0}. Czas wykonania dodawania AVL: {1}, klucz: {2}, zawartośś {3}", j, ts2.TotalMilliseconds, randomKey, randomValue);
            }

            Console.WriteLine();

            for (int j = 1; j <= 10; j++)
            {
                int randomSearchKey = random.Next(1, 100);

                DateTime start1 = DateTime.Now;
                NodeBST nodeBST = treeBST.Search(randomSearchKey, treeBST.root);
                DateTime end1 = DateTime.Now;
                TimeSpan ts1 = (end1 - start1);
                Console.WriteLine("{0}. Czas wykonania znajdowania BST: {1}, klucz: {2}, czy znaleziono: {3}", j, ts1.TotalMilliseconds, randomSearchKey, nodeBST != null ? "Tak" : "Nie");

                DateTime start2 = DateTime.Now;
                NodeAVL nodeAVL = treeAVL.Search(randomSearchKey, treeAVL.root);
                DateTime end2 = DateTime.Now;
                TimeSpan ts2 = (end2 - start2);
                Console.WriteLine("{0}. Czas wykonania znajdowania AVL: {1}, klucz: {2}, czy znaleziono: {3}", j, ts2.TotalMilliseconds, randomSearchKey, nodeAVL != null ? "Tak" : "Nie");
            }

            Console.WriteLine();

            for (int j = 1; j <= 10; j++)
            {
                int randomRemoveKey = random.Next(1, 100);

                DateTime start1 = DateTime.Now;
                bool nodeBST = treeBST.Remove(randomRemoveKey);
                DateTime end1 = DateTime.Now;
                TimeSpan ts1 = (end1 - start1);
                Console.WriteLine("{0}. Czas wykonania usuwania BST: {1}, klucz: {2}, czy usunięto: {3}", j, ts1.TotalMilliseconds, randomRemoveKey, nodeBST ? "Tak" : "Nie");

                DateTime start2 = DateTime.Now;
                bool nodeAVL = treeAVL.Remove(randomRemoveKey);
                DateTime end2 = DateTime.Now;
                TimeSpan ts2 = (end2 - start2);
                Console.WriteLine("{0}. Czas wykonania usuwania AVL: {1}, klucz: {2}, czy usunięto: {3}", j, ts2.TotalMilliseconds, randomRemoveKey, nodeAVL ? "Tak" : "Nie");
            }

            Console.WriteLine();
        }

        //daneDoArkusza(random);
    }

    static void daneDoArkusza(Random random)
    {
        double[,,] arr = new double[20, 20, 7];

        for (int i = 0; i < 20; i++)
        {
            BST treeBST = new BST();
            AVL treeAVL = new AVL();

            for (int j = 0; j <= i; j++)
            {
                int randomKey;
                int randomValue;

                randomKey = random.Next(1, 100);
                randomValue = random.Next(1, 100);

                DateTime start1 = DateTime.Now;
                treeBST.Insert(randomKey, randomValue);
                DateTime end1 = DateTime.Now;
                TimeSpan ts1 = (end1 - start1);

                DateTime start2 = DateTime.Now;
                treeAVL.Insert(randomKey, randomValue);
                DateTime end2 = DateTime.Now;
                TimeSpan ts2 = (end2 - start2);

                arr[i, j, 0] = j + 1;
                arr[i, j, 1] = randomKey;
                arr[i, j, 2] = randomValue;
                arr[i, j, 3] = ts1.TotalMilliseconds;
                arr[i, j, 4] = ts2.TotalMilliseconds;
            }

            for (int j = 0; j <= i; j++)
            {
                int randomKey = (int)arr[i, j, 1];

                DateTime start3 = DateTime.Now;
                NodeBST nodeBST = treeBST.Search(randomKey, treeBST.root);
                DateTime end3 = DateTime.Now;
                TimeSpan ts3 = (end3 - start3);

                DateTime start4 = DateTime.Now;
                NodeAVL nodeAVL = treeAVL.Search(randomKey, treeAVL.root);
                DateTime end4 = DateTime.Now;
                TimeSpan ts4 = (end4 - start4);

                arr[i, j, 5] = ts3.TotalMilliseconds;
                arr[i, j, 6] = ts4.TotalMilliseconds;
            }
        }

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.WriteLine("{0};{1};{2};{3};{4};{5};{6};", arr[i, j, 0], arr[i, j, 1], arr[i, j, 2], arr[i, j, 3], arr[i, j, 4], arr[i, j, 5], arr[i, j, 6]);
            }
        }
    }
}