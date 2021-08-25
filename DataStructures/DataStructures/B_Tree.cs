using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class B_Tree<T> where T : IComparable
    {
        internal B_TreeNode<T> root;
        public int degree;
        public int minDegree;

        B_Tree(int d)
        {
            root = null;
            degree = d;
            minDegree = d / 2;
        }

        void Insert(T k)
        {
            if(root == null)
            {
                root = new B_TreeNode<T>(minDegree, true);
                root.keys[0] = k;
                root.length = 1;
            }
            else
            {
                if(root.length == (degree - 1))
                {
                    B_TreeNode<T> newNode = new B_TreeNode<T>(degree, false);
                    newNode.childs[0] = root;
                    newNode.SplitChild(0, root);

                    int i = 0;
                    if(newNode.keys[0].CompareTo(k) == -1)
                    {
                        i++;
                    }
                    newNode.childs[i].InsertKey(k);

                    root = newNode;
                }
                else
                {
                    root.InsertKey(k);
                }
            }
        }

        B_TreeNode<T> search(T k)
        {
            if(root != null)
            {
                return root.Search(k);
            }
            else
            {
                return null;
            }
        }
        
        void Remove(T k)
        {
            if(root != null)
            {
                root.remove(k);

                if(root.length == 0)
                {
                    B_TreeNode<T> tmp = root;
                    if(root.leaf)
                    {
                        root = null;
                    }
                    else
                    {
                        root = root.childs[0];
                    }
                }
            }
        }
    }
}
