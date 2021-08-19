using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class B_Tree<T> where T : IComparable
    {
        public B_TreeNode<T> root;
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

        
    }
}
