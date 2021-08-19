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
    }
}
