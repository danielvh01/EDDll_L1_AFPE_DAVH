using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class B_TreeNode<T> where T : IComparable
    {
        public T[] keys;
        int maximun;
        int minimum;
        public B_TreeNode<T>[] childs;
        public int length;
        public bool leaf;

        public B_TreeNode(int degree, bool l)
        {
            maximun = degree - 1;
            minimum = degree / 2 - 1;
            leaf = l;
            keys = new T[maximun];
            childs = new B_TreeNode<T>[maximun + 1];
            length = 0;
        }

        public void InsertKey(T k)
        {
            int i = length - 1;

            if( leaf )
            {
                while (i >= 0 && keys[i].CompareTo(k) == 1)
                {
                    keys[i + 1] = keys[i];
                    i--;
                }

                keys[i + 1] = k;
                length++;
            }
            else
            {
                while (i >= 0 && keys[i].CompareTo(k) == 1)
                {
                    i--;
                }
                if(childs[i + 1].length == maximun)
                {
                    SplitChild(i + 1, childs[i + 1]);

                    if(keys[i + 1].CompareTo(k) == -1)
                    {
                        i++;
                    }
                }
                childs[i + 1].InsertKey(k);
            }
        }

        void SplitChild(int i, B_TreeNode<T> y)
        {
            B_TreeNode<T> z = new B_TreeNode<T>(y.length, y.leaf);
            z.length = minimum - 1;

            for (int j = 0; j < minimum - 1; j++)
            {
                z.keys[j] = y.keys[j + minimum];
            }

            if (y.leaf == false)
            {
                for (int j = 0; j < minimum; j++)
                {
                    z.childs[j] = y.childs[j + minimum];
                }
            }

            y.length = minimum - 1;

            for (int j = length; j >= i + 1; j--)
            {
                childs[j + 1] = childs[j];
            }
            childs[i + 1] = z;

            for (int j = length - 1; j >= i; j--)
            {
                keys[j + 1] = keys[j];
            }

            keys[i] = y.keys[minimum - 1];
            length = length + 1;


        }
    }
}
