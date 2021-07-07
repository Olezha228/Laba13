using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace RealLaba13
{
    public delegate void CollectionHandler<Person>(object source, CollectionHandlerEventArgs args);

    public class MySearchTree: SearchTree<Person>
    {
        public string Name { get; }

        public List<Person> data;

        public event CollectionHandler<Person> CollectionCountChanged;
        public event CollectionHandler<Person> CollectionReferenceChanged;

        //constructors

        public MySearchTree(string name) : base()
        {
            Name = name;
        }

        public MySearchTree(int size, string name) : base(size)
        {
            Name = name;
        }



        //indexator

        public Person this[int i]
        {
            get
            {
                if (i < Count)
                {
                    data = this.ToList();
                    return data[i];
                }
                else
                    throw new IndexOutOfRangeException();
            }

            set { }
        }

        //методы
        void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke((MySearchTree)source, args);
        }

        void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke((MySearchTree)source, args);
        }

        //методы

        int len = 0;
        public override int FindCount(Node<Person> node)
        {
            if (node == null) return len;
            len++;
            FindCount(node.left);
            FindCount(node.right);
            return len;
        }

        public void Add()
        {
            Student stud = (Student)new Student().Init();
            Insert(stud);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("CollectionCountChanged", Name, stud));
        }

        bool ok;
        public override void DeleteLeaf(Node<Person> node)
        {
            ok = true;
            DeleteLeafBasical(node);
        }
        public void DeleteLeafBasical(Node<Person> node)
        {
            if (node == null) return;
            if ((top.left == null) && (top.right == null))
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs("CollectionCountChanged", Name, top.data));
                top = null;
                ok = false;
            }

            if (node.left != null)
                if ((node.left.left == null) && (node.left.right == null))
                {
                    OnCollectionCountChanged(this, new CollectionHandlerEventArgs("CollectionCountChanged", Name, node.left.data));
                    node.left = null;
                    ok = false;
                    return;
                }

            if (node.right != null)
                if ((node.right.left == null) && (node.right.right == null))
                {
                    OnCollectionCountChanged(this, new CollectionHandlerEventArgs("CollectionCountChanged", Name, node.right.data));
                    node.right = null;
                    ok = false;
                    return;
                }
            if (ok)
                DeleteLeafBasical(node.left);
            if(ok)
                DeleteLeafBasical(node.right);
            
        }

        bool isContinued;
        public void ExchangeLeaf(Node<Person> node)
        {
            isContinued = true;
            ExchangeLeafBasical(node);
        }
        public void ExchangeLeafBasical(Node<Person> node)
        {
            if (node == null) return;
            if (node.left != null)
                if ((node.left.left == null) && (node.left.right == null))
                {
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("CollectionReferenceChanged", Name, node.left.data));
                    int age = node.left.data.Age;
                    node.left.data = (Student)(new Student()).Init();
                    node.left.data.Age = age;
                    isContinued = false;
                    return;
                }

            else if (node.right != null)
                if ((node.right.left == null) && (node.right.right == null))
                {
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("CollectionReferenceChanged", Name, node.right.data));
                    int age = node.right.data.Age;
                    node.right.data = (Student)(new Student()).Init();
                    node.right.data.Age = age;
                    isContinued = false;
                    return;
                }

            if (isContinued)
                ExchangeLeafBasical(node.left);
            if (isContinued)
                ExchangeLeafBasical(node.right);            
        }
    }
}
