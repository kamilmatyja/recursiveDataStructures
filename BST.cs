using System;

namespace RecursiveDataStructuresK81
{
    public class NodeBST
    {
        public int Key;
        public int Value;
        public NodeBST Less;
        public NodeBST Greater;

        public NodeBST(int key, int value)
        {
            Key = key;
            Value = value;
            Less = null;
            Greater = null;
        }
    }

    public class BST
    {
        public NodeBST root;

        public NodeBST Search(int key, NodeBST currentNode)
        {
            if (currentNode == null || currentNode.Key == key)
                return currentNode;
            if (currentNode.Key > key)
                return Search(key, currentNode.Less);
            return Search(key, currentNode.Greater);
        }

        public bool Insert(int key, int value)
        {
            if (root == null)
            {
                root = new NodeBST(key, value);
                return true;
            }
            var currentNode = root;
            while (true)
            {
                if (key == currentNode.Key)
                    return false;
                if (key < currentNode.Key)
                {
                    if (currentNode.Less == null)
                    {
                        currentNode.Less = new NodeBST(key, value);
                        return true;
                    }
                    currentNode = currentNode.Less;
                }
                else
                {
                    if (currentNode.Greater == null)
                    {
                        currentNode.Greater = new NodeBST(key, value);
                        return true;
                    }
                    currentNode = currentNode.Greater;
                }
            }
        }

        private NodeBST MaxFromSubtree(NodeBST node)
        {
            if (node.Greater == null)
                return node;
            return MaxFromSubtree(node.Greater);
        }

        public bool Remove(int key)
        {
            var rmPosition = Search(key, root);
            if (rmPosition == null)
                return false;
            if (rmPosition.Less == null || rmPosition.Greater == null)
            {
                rmPosition = rmPosition.Less ?? rmPosition.Greater;
                return true;
            }
            var maxLess = MaxFromSubtree(rmPosition.Less);
            Remove(maxLess.Key);
            rmPosition.Key = maxLess.Key;
            rmPosition.Value = maxLess.Value;
            return true;
        }

        public void Traverse(NodeBST node)
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
    }
}