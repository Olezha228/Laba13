using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace RealLaba13
{
    public class Node<T>
        where T : Person
    {
        public Person data;
        public Node<T> left;
        public Node<T> right;
        public Node<T> ParentNode;

        public Node()
        {
            data = null;
            left = null;
            right = null;
        }

        public Node(T d)
        {
            Person p = new Person();
            Random rnd = new Random();
            int k = rnd.Next(1, 5);
            switch (k)
            {
                case 1:
                    p = (Person)new Student().Init();
                    break;
                case 2:
                    p = (Person)new Schooler().Init();
                    break;
                case 3:
                    p = (Person)new CorrespondenceStudent().Init();
                    break;
                case 4:
                    p = (Person)new Person().Init();
                    break;
            }
            data = p;
            left = null;
            right = null;
        }

        public Node(T d, bool ok)
        {
            data = (T)(Person)d;
            left = null;
            right = null;
        }

        public override string ToString()
        {
            return data + " ";
        }

        public void Insert(T value)
        {
            int dif = ((Person)value).CompareTo(data);
            if (dif > 0)
            {
                if (right == null)
                {
                    right = new Node<T>(value, true);
                }
                else
                {
                    right.Insert(value);
                }
            }
            else
            {
                if (left == null)
                {
                    left = new Node<T>(value, true);
                }
                else
                {
                    left.Insert(value);
                }
            }
        }
    }
}
