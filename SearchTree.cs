using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;
using System.Collections;

namespace RealLaba13
{
    public class SearchTree<T> : IEnumerable<T>
        where T : Person, new()
    {
        public Node<T> top;
        public static int ageController1 = 5;
        public static int ageController2 = 5;

        //свойства
        public int Count
        {
            get
            {
                len = 0;
                int c = FindCount(top);
                return c;
            }
        }

        //конструкторы
        public SearchTree()
        {
            top = null;
        }

        public SearchTree(int size)
        {
            Random r = new Random();
            List<Person> list = new List<Person>();
            Person p = (Person)new Person().Init();
            for (int i = 0; i < size; i++)
            {
                if (i % 4 == 0)
                {
                    Person per = (Person)new Person().Init();
                    per.Age = r.Next(1, 1000);
                    list.Add(per);
                }
                if (i % 4 == 1)
                {
                    Student per = (Student)new Student().Init();
                    per.Age = r.Next(1, 1000);
                    list.Add(per);
                }
                if (i % 4 == 2)
                {
                    CorrespondenceStudent per = (CorrespondenceStudent)new CorrespondenceStudent().Init();
                    per.Age = r.Next(1, 1000);
                    list.Add(per);
                }
                if (i % 4 == 3)
                {
                    Schooler per = (Schooler)new Schooler().Init();
                    per.Age = r.Next(1, 1000);
                    list.Add(per);
                }
            }

            foreach (var el in list)
                Insert((T)el);
        }

        public SearchTree(SearchTree<T> c)
        {
            top = c.CloneNode(top, c.top);
        }

        // Методы
        int len = 0;
        public virtual int FindCount(Node<T> node)
        {
            if (node == null) return len;
            len++;
            FindCount(node.left);
            FindCount(node.right);
            return len;
        }

        public virtual void Insert(T data)
        {
            if (top != null)
            {
                top.Insert((T)data);
            }
            else
            {
                top = new Node<T>((T)data, true);
            }
        }

        public virtual void InsertMany(int number)
        {
            Person p = (Person)new Person().Init();
            p.Age = ageController1;
            ageController1 += 11;


            if (number < 1) return;
            if (number == 1) Insert((T)p);
            else
            {
                List<Person> list = new List<Person>();
                for (int i = 0; i < number; i++)
                {
                    Person per = (Person)new Person().Init();
                    if (i % 2 == 0)
                    {
                        per.Age = ageController1;
                        ageController1 += 11;
                        if (i % 3 == 1)
                            ageController1 -= 27;
                    }
                    else
                    {
                        per.Age = ageController2;
                        ageController2 += 3;
                        if (i % 4 == 1)
                            ageController2 -= 7;
                    }
                    list.Add(per);
                }

                foreach (var el in list)
                    Insert((T)el);
            }
        }

        public virtual SearchTree<T> CloneTree()
        {
            SearchTree<T> sTree = new SearchTree<T>();
            sTree.top = CloneNode(sTree.top, top);
            return sTree;
        }

        Node<T> CloneNode(Node<T> node, Node<T> thisNode)
        {
            if (thisNode == null) return null;
            node = new Node<T>();
            node.data = new Person(thisNode.data.name, thisNode.data.Age, thisNode.data.Height, thisNode.data.Weight);
            node.left = CloneNode(node.left, thisNode.left);
            node.right = CloneNode(node.right, thisNode.right);
            return node;
        }

        public SearchTree<T> Copy()
        {
            return this;
        }

        public void PrintTree(Node<T> root, int space)
        {
            if (root == null)
            {
                return;
            }

            space += 10;

            PrintTree(root.right, space);

            Console.Write("\n");
            for (int i = 10; i < space; i++)
                Console.Write(" ");
            Console.Write(root.data + "\n");

            // Process left child 
            PrintTree(root.left, space);
        }

        public virtual void Delete()
        {
            if (top != null)
            {
                top = null;
                Tree<Person>.list = new List<Person>();
            }
        }

        public bool Exists(int age, Node<T> node)
        {
            bool ok = false;
            if (node == null) return false;
            if (node.data.Age == age) return true;
            if (age < node.data.Age) ok = Exists(age, node.left);
            else ok = Exists(age, node.right);
            return ok;
        }

        public Node<T> FindNode(int age, Node<T> root)
        {
            Node<T> node = root;
            if (node == null) return node;
            if (node.data.Age == age) return node;
            if (age < node.data.Age) node = FindNode(age, node.left);
            else node = FindNode(age, node.right);
            return node;
        }

        public virtual void DeleteLeaves(Node<T> node)
        {
            if (node == null) return;
            if (node.left != null)
                if ((node.left.left == null) && (node.left.right == null))
                    node.left = null;

            if (node.right != null)
                if ((node.right.left == null) && (node.right.right == null))
                    node.right = null;
            DeleteLeaves(node.left);
            DeleteLeaves(node.right);
        }

        public virtual void DeleteLeaf(Node<T> node)
        {
            if (node == null) return;
            if (node.left != null)
                if ((node.left.left == null) && (node.left.right == null))
                    node.left = null;

            if (node.right != null)
                if ((node.right.left == null) && (node.right.right == null))
                {
                    node.right = null;
                    return;
                }
            DeleteLeaf(node.left);
            DeleteLeaf(node.right);
        }

        // Нумераторы
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)new List<int>();
        }

        public IEnumerable<T> Inorder()
        {
            if (top == null) yield break;

            var stack = new Stack<Node<T>>();
            var node = top;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return (T)node.data;
                    node = node.right;
                }
                else
                {
                    stack.Push(node);
                    node = node.left;
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Inorder().GetEnumerator();
        }
    }
}
