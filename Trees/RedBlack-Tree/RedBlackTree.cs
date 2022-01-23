using System;

namespace Trees.RedBlack_Tree
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        private bool leftLeftRotation = false;
        private bool rightRightRotation = false;
        private bool leftRightRotation = false;
        private bool rightLeftRotation = false;
        public Node<T> Root { get; set; }
        public RedBlackTree()
        {
            this.Root = null;
        }
        public void Insert(T value)
        {
            if(this.Root == null)
            {
                var newNode = new Node<T>(value);
                this.Root = newNode;
                this.Root.Color = Color.Black;
            }
            else
            {
                this.Root = Insert(this.Root, value);
            }
        }
        public void PrintTree(int spaces = 0)
        {
            this.PrintTree(this.Root, spaces);
        }

        private void PrintTree(Node<T> node, int spaces)
        {
            if (node == null) return;
            PrintTree(node.LeftChild, spaces + 5);
            Console.Write(new string(' ', spaces));
            Console.WriteLine(node);
            PrintTree(node.RightChild, spaces + 5);
        }

        private Node<T> Insert(Node<T> root, T value)
        {
            bool doubleRed = false;
            if (root == null)
            {
                return new Node<T>(value);
            }
            else if (value.CompareTo(root.Value) < 0)
            {
                root.LeftChild = Insert(root.LeftChild, value);
                root.LeftChild.Parent = root;
                doubleRed = CheckForDoubleRed(root, root.LeftChild);
            }
            else
            {
                root.RightChild = Insert(root.RightChild, value);
                root.RightChild.Parent = root;
                doubleRed = CheckForDoubleRed(root, root.RightChild);
            }
            // Rotations if needed
            root = Rotate(root);
            //Fix double Red if needed
            root = Recolor(root, doubleRed);
            return root;

        }
        public void Delete(T value)
        {
            throw new NotImplementedException();
        }
        private Node<T> Recolor(Node<T> root, bool doubleRed)
        {
            if (doubleRed)
            {
                //Check current node of its parent
                if (root.Parent.RightChild == root)
                {
                    if (root.Parent.LeftChild == null || root.Parent.LeftChild.Color == Color.Black)
                    {
                        if (root.LeftChild != null && root.LeftChild.Color == Color.Red)
                        {
                            this.rightLeftRotation = true;
                        }
                        else if (root.RightChild != null && root.RightChild.Color == Color.Red)
                        {
                            this.leftLeftRotation = true;
                        }
                    }
                    else // when uncle node is red
                    {
                        root.Parent.LeftChild.Color = Color.Black;
                        root.Color = Color.Black;
                        if (root.Parent != this.Root)
                        {
                            root.Parent.Color = Color.Red;
                        }
                    }
                }
                else
                {
                    if (root.Parent.RightChild == null || root.Parent.RightChild.Color == Color.Black)
                    {
                        if (root.LeftChild != null && root.LeftChild.Color == Color.Red)
                        {
                            this.rightRightRotation = true;
                        }
                        else if (root.RightChild != null && root.RightChild.Color == Color.Red)
                        {
                            this.leftRightRotation = true;
                        }
                    }
                    else
                    {
                        root.Parent.RightChild.Color = Color.Black;
                        root.Color = Color.Black;
                        if (root.Parent != this.Root)
                        {
                            root.Parent.Color = Color.Red;
                        }
                    }
                }
                doubleRed = false;
            }
            return root;
        }
        private Node<T> Rotate(Node<T> root)
        {
            if (this.leftLeftRotation)
            {
                root = LeftRotation(root);
                root.Color = Color.Black;
                root.LeftChild.Color = Color.Red;
                this.leftLeftRotation = false;
            }
            else if (this.rightRightRotation)
            {
                root = RightRotation(root);
                root.Color = Color.Black;
                root.RightChild.Color = Color.Red;
                this.rightRightRotation = false;
            }
            else if (this.leftRightRotation)
            {
                root.LeftChild = LeftRotation(root.LeftChild);
                root.LeftChild.Parent = root;
                root = RightRotation(root);
                root.Color = Color.Black;
                root.RightChild.Color = Color.Red;
                this.leftRightRotation = false;
            }
            else if (this.rightLeftRotation)
            {
                root.RightChild = RightRotation(root.RightChild);
                root.RightChild.Parent = root;
                root = LeftRotation(root);
                root.Color = Color.Black;
                root.LeftChild.Color = Color.Red;
                this.rightLeftRotation = false;
            }
            return root;
        }
        private bool CheckForDoubleRed(Node<T> node, Node<T> child)
        {
            if (node != this.Root)
            {
                if (node.Color == Color.Red && child.Color == Color.Red)
                {
                    return true;
                }
            }
            return false;
        }

        private Node<T> LeftRotation(Node<T> node)
        {
            var right = node.RightChild;
            var subLeft = node.LeftChild;
            right.LeftChild = node;
            node.RightChild = subLeft;
            node.Parent = right;
            if(subLeft != null)
            {
                subLeft.Parent = node;
            }
            return right;
        }
        private Node<T> RightRotation(Node<T> node)
        {
            var left = node.LeftChild;
            var subRight = node.RightChild;
            left.RightChild = node;
            node.LeftChild = subRight;
            node.Parent = left;
            if (subRight != null)
            {
                subRight.Parent = node;
            }
            return left;
        }
    }
}
