namespace RecursiveDataStructuresK81
{
    // definicja węzła drzewa AVL
    public class NodeAVL
    {
        public int key;
        public int height;
        public NodeAVL left, right;

        public NodeAVL(int item)
        {
            key = item;
            height = 1;
            left = right = null;
        }
    }

    // definicja drzewa AVL
    public class AVL
    {
        public NodeAVL root;

        // konstruktor
        public AVL()
        {
            root = null;
        }

        // dodanie elementu
        public void Insert(int key)
        {
            root = InsertRec(root, key);
        }

        // rekurencyjne dodawanie elementu w odpowiednim miejscu poprzez sprawdzanie czy klucz mniejszy / większy
        private NodeAVL InsertRec(NodeAVL root, int key)
        {
            if (root == null)
            {
                root = new NodeAVL(key);
                return root;
            }

            if (key < root.key)
                root.left = InsertRec(root.left, key);
            else if (key > root.key)
                root.right = InsertRec(root.right, key);
            else
                return root;

            root.height = 1 + Max(Height(root.left), Height(root.right));

            int balance = GetBalance(root);

            if (balance > 1 && key < root.left.key)
                return RightRotate(root);

            if (balance < -1 && key > root.right.key)
                return LeftRotate(root);

            if (balance > 1 && key > root.left.key)
            {
                root.left = LeftRotate(root.left);
                return RightRotate(root);
            }

            if (balance < -1 && key < root.right.key)
            {
                root.right = RightRotate(root.right);
                return LeftRotate(root);
            }

            return root;
        }

        // usunięcie elementu
        public void Delete(int key)
        {
            root = DeleteRec(root, key);
        }

        // rekurencyjne usuwanie elementu z odpowiedniego miejsca
        private NodeAVL DeleteRec(NodeAVL root, int key)
        {
            if (root == null) return root;

            if (key < root.key)
                root.left = DeleteRec(root.left, key);
            else if (key > root.key)
                root.right = DeleteRec(root.right, key);
            else
            {
                if ((root.left == null) || (root.right == null))
                {
                    NodeAVL temp = null;
                    if (temp == root.left)
                        temp = root.right;
                    else
                        temp = root.left;

                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else
                        root = temp;
                }
                else
                {
                    NodeAVL temp = MinValue(root.right);

                    root.key = temp.key;

                    root.right = DeleteRec(root.right, temp.key);
                }
            }

            if (root == null)
                return root;

            root.height = 1 + Max(Height(root.left), Height(root.right));

            int balance = GetBalance(root);

            // niezrównoważenie w lewej poddrzewie
            if (balance > 1 && GetBalance(root.left) >= 0)
                return RightRotate(root);

            // niezrównoważenie w prawej poddrzewie
            if (balance < -1 && GetBalance(root.right) <= 0)
                return LeftRotate(root);
            // niezrównoważenie w lewym-prawym poddrzewie
            if (balance > 1 && GetBalance(root.left) < 0)
            {
                root.left = LeftRotate(root.left);
                return RightRotate(root);
            }

            // niezrównoważenie w prawym-lewym poddrzewie
            if (balance < -1 && GetBalance(root.right) > 0)
            {
                root.right = RightRotate(root.right);
                return LeftRotate(root);
            }

            return root;
        }

        // pobieranie najmniejszego elementu
        private NodeAVL MinValue(NodeAVL NodeAVL)
        {
            NodeAVL current = NodeAVL;

            while (current.left != null)
                current = current.left;

            return current;
        }

        // wysokość węzła
        private int Height(NodeAVL NodeAVL)
        {
            if (NodeAVL == null) return 0;

            return NodeAVL.height;
        }

        // maksymalna wartość
        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // rotacja w prawo
        private NodeAVL RightRotate(NodeAVL y)
        {
            NodeAVL x = y.left;
            NodeAVL T2 = x.right;

            x.right = y;
            y.left = T2;

            y.height = Max(Height(y.left), Height(y.right)) + 1;
            x.height = Max(Height(x.left), Height(x.right)) + 1;

            return x;
        }

        // rotacja w lewo
        private NodeAVL LeftRotate(NodeAVL x)
        {
            NodeAVL y = x.right;
            NodeAVL T2 = y.left;

            y.left = x;
            x.right = T2;

            x.height = Max(Height(x.left), Height(x.right)) + 1;
            y.height = Max(Height(y.left), Height(y.right)) + 1;

            return y;
        }

        // różnica wysokości lewego i prawego poddrzewa
        private int GetBalance(NodeAVL NodeAVL)
        {
            if (NodeAVL == null) return 0;

            return Height(NodeAVL.left) - Height(NodeAVL.right);
        }

        // dostęp do elementu o określonym kluczu
        public NodeAVL Search(int key)
        {
            return SearchRec(root, key);
        }

        // rekurencyjne przeszukiwanie
        private NodeAVL SearchRec(NodeAVL root, int key)
        {
            if (root == null || root.key == key)
                return root;

            if (root.key < key)
                return SearchRec(root.right, key);

            return SearchRec(root.left, key);
        }

        // iteracja po elementach w sposób rosnący po kluczu elementu
        public void Traverse(NodeAVL root)
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