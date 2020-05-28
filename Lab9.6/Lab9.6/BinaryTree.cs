using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab9._6
{
    public class BinaryTree
    {
        BinaryTreeNode root = null;

        public void PreOrder (BinaryTreeNode node)
        {
            if(node != null)
            {
                Console.Write(node.data + " ");
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }
        public void InOrder (BinaryTreeNode node, int level = 0)
        {
            if( node != null)
            {
                InOrder(node.left, level + 1);
                for (int i = 0; i < level; i++)
                    Console.Write("          ");
                Console.WriteLine(node.data.toString() + "\n");
                InOrder(node.right, level + 1); 
            }
        }
        public void InOrderTraversal()
        {
            InOrder(root);
        }
        public BinaryTreeNode AddRoot(Game data)
        {
            root = new BinaryTreeNode { data = data };
            return root;
        }
        public BinaryTreeNode AddLeft(BinaryTreeNode node, Game data)
        {
            BinaryTreeNode newNode = new BinaryTreeNode { data = data };
            node.left = newNode;
            return newNode;
        }
        public BinaryTreeNode AddRight(BinaryTreeNode node, Game data)
        {
            BinaryTreeNode newNode = new BinaryTreeNode { data = data };
            node.right = newNode;
            return newNode;
        }
    }
}
