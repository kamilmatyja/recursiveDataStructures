using System;

namespace RecursiveDataStructuresK81
{
    public class NodeAVL
    {
        public int Key;
        public int Value;
        public NodeAVL Less;
        public NodeAVL Greater;
        public int Height;

        public NodeAVL(int key, int value)
        {
            Key = key;
            Value = value;
            Less = null;
            Greater = null;
            Height = 0;
        }
    }

    public class AVL
    {
        public NodeAVL root;

        public NodeAVL Search(int key, NodeAVL currentNode)
        {
            while (currentNode != null)
            {
                if (key == currentNode.Key)
                {
                    return currentNode;
                }
                else if (key < currentNode.Key)
                {
                    currentNode = currentNode.Less;
                }
                else
                {
                    currentNode = currentNode.Greater;
                }
            }

            return null;
        }

        public void Insert(int key, int value)
        {
            root = Insert(root, key, value);
        }

        public NodeAVL Insert(NodeAVL node, int key, int value)
        {
            if (node == null)
            {
                return new NodeAVL(key, value);
            }

            if (key < node.Key)
            {
                node.Less = Insert(node.Less, key, value);
            }
            else if (key > node.Key)
            {
                node.Greater = Insert(node.Greater, key, value);
            }
            else
            {
                node.Value = value;
            }

            node.Height = 1 + Math.Max(GetHeight(node.Less), GetHeight(node.Greater));

            int balance = GetBalance(node);

            if (balance > 1 && key < node.Less.Key)
            {
                return RotateRight(node);
            }

            if (balance < -1 && key > node.Greater.Key)
            {
                return RotateLeft(node);
            }

            if (balance > 1 && key > node.Less.Key)
            {
                node.Less = RotateLeft(node.Less);
                return RotateRight(node);
            }

            if (balance < -1 && key < node.Greater.Key)
            {
                node.Greater = RotateRight(node.Greater);
                return RotateLeft(node);
            }

            return node;
        }

        public void Remove(int key)
        {
            root = Remove(root, key);
        }

        public NodeAVL Remove(NodeAVL node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (key < node.Key)
            {
                node.Less = Remove(node.Less, key);
            }
            else if (key > node.Key)
            {
                node.Greater = Remove(node.Greater, key);
            }
            else
            {
                if (node.Less == null || node.Greater == null)
                {
                    NodeAVL temp = null;

                    if (temp == node.Less)
                    {
                        temp = node.Greater;
                    }
                    else
                    {
                        temp = node.Less;
                    }

                    if (temp == null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                    {
                        node = temp;
                    }
                }
                else
                {
                    NodeAVL temp = MinValueNode(node.Greater);

                    node.Key = temp.Key;
                    node.Value = temp.Value;

                    node.Greater = Remove(node.Greater, temp.Key);
                }
            }

            if (node == null)
            {
                return null;
            }

            node.Height = 1 + Math.Max(GetHeight(node.Less), GetHeight(node.Greater));

            int balance = GetBalance(node);

            if (balance > 1 && GetBalance(node.Less) >= 0)
            {
                return RotateRight(node);
            }

            if (balance > 1 && GetBalance(node.Less) < 0)
            {
                node.Less = RotateLeft(node.Less);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalance(node.Greater) <= 0)
            {
                return RotateLeft(node);
            }

            if (balance < -1 && GetBalance(node.Greater) > 0)
            {
                node.Greater = RotateRight(node.Greater);
                return RotateLeft(node);
            }

            return node;
        }

        private void Traverse(NodeAVL node)
        {
            if (node != null)
            {
                Traverse(node.Less);
                Console.WriteLine($"{node.Key}, {node.Value}");
                Traverse(node.Greater);
            }
        }

        public void PrintTree()
        {
            Traverse(root);
        }

        private NodeAVL RotateRight(NodeAVL node)
        {
            NodeAVL leftChild = node.Less;
            NodeAVL rightGrandchild = leftChild.Greater;

            leftChild.Greater = node;
            node.Less = rightGrandchild;

            node.Height = 1 + Math.Max(GetHeight(node.Less), GetHeight(node.Greater));
            leftChild.Height = 1 + Math.Max(GetHeight(leftChild.Less), GetHeight(leftChild.Greater));

            return leftChild;
        }

        private NodeAVL RotateLeft(NodeAVL node)
        {
            NodeAVL rightChild = node.Greater;
            NodeAVL leftGrandchild = rightChild.Less;

            rightChild.Less = node;
            node.Greater = leftGrandchild;

            node.Height = 1 + Math.Max(GetHeight(node.Less), GetHeight(node.Greater));
            rightChild.Height = 1 + Math.Max(GetHeight(rightChild.Less), GetHeight(rightChild.Greater));

            return rightChild;
        }

        private int GetHeight(NodeAVL node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private int GetBalance(NodeAVL node)
        {
            if (node == null)
            {
                return 0;
            }

            return GetHeight(node.Less) - GetHeight(node.Greater);
        }

        private NodeAVL MinValueNode(NodeAVL node)
        {
            NodeAVL current = node;

            while (current.Less != null)
            {
                current = current.Less;
            }

            return current;
        }
    }
}