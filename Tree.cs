using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace RealLaba13
{
    class Tree<T>
        where T : Person
    {
        public Node<T> top = null;
        private int size;
        static readonly int count = 20;
        private int leaves = 0;
        public static List<Person> list = new List<Person>();

        public int Size { get { return size; } }
        public int Leaves { get { return leaves; } }

        //конструкторы
        public Tree() { }

        public Tree(int size)
        {
            if (size == 1) top = new Node<T>((T)new Person());
            if (size < 1) return;
            this.size = size;
            top = IdealTree(size, top);
        }

        //методы
        public void PrintTree(Node<T> root, int space)
        {
            if (root == null)
            {
                return;
            }

            space += count;

            PrintTree(root.right, space);

            Console.Write("\n");
            for (int i = count; i < space; i++)
                Console.Write(" ");
            Console.Write(root.data + "\n");

            // Process left child 
            PrintTree(root.left, space);
        }

        public void PrintTree1(Node<T> root, int space)
        {
            if (top == null)
                Console.WriteLine("Дерево пусто!");
            PrintTree(root, space);
        }

        static Node<T> IdealTree(int size, Node<T> node)
        {
            node = new Node<T>((T)new Person());
            int countR, countL;
            size--;
            if (size == -1) return null;
            if (size % 2 == 0)
            {
                countL = size / 2;
                countR = size / 2;
            }
            else
            {
                countL = size / 2 + 1;
                countR = size - countL;
            }
            node.left = IdealTree(countL, node.left);
            node.right = IdealTree(countR, node.right);
            return node;
        }

        public int FindLeaves(Node<T> node)
        {
            if (node != null)
            {
                if ((node.left == null) && (node.right == null))
                    leaves++;
                FindLeaves(node.left);
                FindLeaves(node.right);
            }
            return leaves;
        }

        public void Insert(T data)
        {
            if (top != null)
            {
                top.Insert(data);
            }
            else
            {
                top = new Node<T>(data);
            }
        }

        public static List<Person> listNode(Node<T> node)
        {
            if (node != null)
            {
                list.Add(node.data);
                listNode(node.left);
                listNode(node.right);
            }
            return list;
        }

        public void Delete()
        {
            if (top != null)
            {
                top.right = null;
                top.left = null;
                top.data = null;
                top = null;
                Tree<Person>.list = new List<Person>();
            }
        }
    }
}
