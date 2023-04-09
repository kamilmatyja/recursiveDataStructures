using System;
namespace RecursiveDataStructuresK81
{
    public class ListNode
    {
        public int key;
        public ListNode next;

        public ListNode(int key)
        {
            this.key = key;
            next = null;
        }
    }

    public class SortedLinkedList
    {
        private ListNode head;

        public SortedLinkedList()
        {
            head = null;
        }

        // dodawanie elementu
        public void Insert(int key)
        {
            ListNode newNode = new ListNode(key);

            if (head == null || head.key >= newNode.key)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                ListNode current = head;

                while (current.next != null && current.next.key < newNode.key)
                {
                    current = current.next;
                }

                newNode.next = current.next;
                current.next = newNode;
            }
        }

        // usuwanie elementu
        public void Delete(int key)
        {
            if (head == null)
            {
                return;
            }

            if (head.key == key)
            {
                head = head.next;
                return;
            }

            ListNode current = head;

            while (current.next != null && current.next.key != key)
            {
                current = current.next;
            }

            if (current.next != null)
            {
                current.next = current.next.next;
            }
        }

        // dostęp do elementu o określonym kluczu
        public ListNode Search(int key)
        {
            ListNode current = head;

            while (current != null && current.key != key)
            {
                current = current.next;
            }

            if (current != null)
            {
                Console.WriteLine("Liczba {0} została znaleziona.", key);
            }
            else
            {
                Console.WriteLine("Liczba {0} nie została znaleziona.", key);
            }

            return current;
        }

        // iterowanie po elementach w sposób rosnący po kluczu elementu
        public void Traverse()
        {
            ListNode current = head;

            while (current != null)
            {
                Console.WriteLine(current.key);
                current = current.next;
            }
        }
    }
}