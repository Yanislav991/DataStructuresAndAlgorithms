﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.AVL_Tree
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLTree()
        {

        }
        public Node<T> Root { get; set; }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (this.Root == null)
            {
                this.Root = newNode;
                return;
            }
            else
            {
                this.Root = this.Add(this.Root, newNode);
            }

        }
        public void Show()
        {
            var sb = new StringBuilder();
            Traverse(sb,"","", this.Root);
            Console.WriteLine(sb.ToString());
        }
        private void Traverse(StringBuilder sb, string padding,string pointer, Node<T> node)
        {
            if (node != null)
            {
                sb.Append(padding);
                sb.Append(pointer);
                sb.Append(node.Data);
                sb.Append("\n");
                StringBuilder paddingBuilder = new StringBuilder(padding);
                paddingBuilder.Append("│  ");
                var paddingForBoth = paddingBuilder.ToString();
                var pointerForRight = "└──";
                var pointerForLeft = (node.RightChild != null) ? "├──" : "└──";
                Traverse(sb,paddingForBoth, pointerForLeft, node.LeftChild);
                Traverse(sb,paddingForBoth,pointerForRight, node.RightChild);
            }
        }
        public bool Contains(T value)
        {
            var node = Contains(value, this.Root);
            if (node == null) return false;
            if (node.Data.CompareTo(value) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(T value)
        {
            this.Root = Delete(this.Root, value);
        }
        private Node<T> Add(Node<T> current, Node<T> newNode)
        {
            if (current == null)
            {
                current = newNode;
                return current;
            }
            else if (newNode.Data.CompareTo(current.Data) < 0)
            {
                current.LeftChild = Add(current.LeftChild, newNode);
                current = BalanceTree(current);
            }
            else if (newNode.Data.CompareTo(current.Data) > 0)
            {
                current.RightChild = Add(current.RightChild, newNode);
                current = BalanceTree(current);
            }
            return current;
        }
        private Node<T> BalanceTree(Node<T> current)
        {
            int balanceFactor = GetBalanceFactor(current);
            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(current.LeftChild) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if(balanceFactor < -1)
            {
                if (GetBalanceFactor(current.RightChild) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        private int GetBalanceFactor(Node<T> current)
        {
            int leftChildHeight = GetHeight(current.LeftChild);
            int rightChildHeight = GetHeight(current.RightChild);
            int balance = leftChildHeight - rightChildHeight;
            return balance;
        }
        private int GetHeight(Node<T> node)
        {
            int height = 0;
            if(node != null)
            {
                int leftChildHeight = GetHeight(node.LeftChild);
                int rightChildHeight = GetHeight(node.RightChild);
                int max = GetMax(leftChildHeight, rightChildHeight);
                height = max + 1;
            }
            return height;
        }
        private int GetMax(int leftChildHeight, int rightChildHeight)
        {
            return leftChildHeight > rightChildHeight ? leftChildHeight : rightChildHeight;
        }
        private Node<T> Contains(T value, Node<T> node)
        {
            if(node == null)
            {
                return null;
            }
            if (value.CompareTo(node.Data) < 0)
            {
                if (value.CompareTo(node.Data) == 0)
                {
                    return node;
                }
                else
                return Contains(value ,node.LeftChild);
            }
            else
            {
                if (value.CompareTo(node.Data) == 0)
                {
                    return node;
                }
                else
                    return Contains(value, node.RightChild);
            }
        }

        private Node<T> Delete(Node<T> node, T value)
        {
            throw new NotImplementedException();
        }
        private Node<T> RotateRL(Node<T> current)
        {
            var newParent = current.RightChild;
            current.RightChild = RotateLL(newParent);
            return RotateRR(current);
        }

        private Node<T> RotateRR(Node<T> current)
        {
            var newParent = current.RightChild;
            current.RightChild = newParent.LeftChild;
            newParent.LeftChild = current;
            return newParent;
        }

        private Node<T> RotateLR(Node<T> current)
        {
            var newParent = current.LeftChild;
            current.LeftChild = RotateRR(newParent);
            return RotateLL(current);
        }

        private Node<T> RotateLL(Node<T> current)
        {
            var newParent = current.LeftChild;
            current.LeftChild = newParent.RightChild;
            newParent.RightChild = current;
            return newParent;
        }

    }
}
