namespace RecursiveDataStructuresK81
{
    // definicja węzła drzewa BST
    public class NodeBST
    {
        public int key;
        public NodeBST left, right;

        public NodeBST(int item)
        {
            key = item;
            left = right = null;
        }
    }

    // definicja drzewa BST
    public class BST
    {
        public NodeBST root;

        // konstruktor
        public BST()
        {
            root = null;
        }

        // dodanie elementu
        public void Insert(int key)
        {
            root = InsertRec(root, key);
        }

        // rekurencyjne dodawanie elementu w odpowiednim miejscu poprzez sprawdzanie czy klucz mniejszy / większy
        private NodeBST InsertRec(NodeBST root, int key)
        {
            if (root == null)
            {
                root = new NodeBST(key);
                return root;
            }

            if (key < root.key)
                root.left = InsertRec(root.left, key);
            else if (key > root.key)
                root.right = InsertRec(root.right, key);

            return root;
        }

        // usunięcie elementu
        public void Delete(int key)
        {
            root = DeleteRec(root, key);
        }

        // rekurencyjne usuwanie elementu z odpowiedniego miejsca
        private NodeBST DeleteRec(NodeBST root, int key)
        {
            if (root == null) return root;

            if (key < root.key)
                root.left = DeleteRec(root.left, key);
            else if (key > root.key)
                root.right = DeleteRec(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.key = MinValue(root.right);

                root.right = DeleteRec(root.right, root.key);
            }

            return root;
        }

        // pobieranie najmniejszego elementu
        private int MinValue(NodeBST root)
        {
            int minvalue = root.key;
            while (root.left != null)
            {
                minvalue = root.left.key;
                root = root.left;
            }
            return minvalue;
        }

        // dostęp do elementu o określonym kluczu
        public NodeBST Search(int key)
        {
            return SearchRec(root, key);
        }

        // rekurencyjne przeszukiwanie
        private NodeBST SearchRec(NodeBST root, int key)
        {
            if (root == null || root.key == key)
                return root;

            if (root.key < key)
                return SearchRec(root.right, key);

            return SearchRec(root.left, key);
        }

        // iterowanie po elementach w sposób rosnący po kluczu elementu
        public void Traverse(NodeBST root)
        {
            if (root != null)
            {
                Traverse(root.left);
                Console.Write(root.key + " ");
                Traverse(root.right);
            }
        }
    }
}