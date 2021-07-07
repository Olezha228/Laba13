using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace RealLaba13
{
    class Program
    {
        static void Menu()
        {
            Console.WriteLine("==============Меню==============");
            Console.WriteLine("1. Добавить элемент в collection1.");
            Console.WriteLine("2. Добавить элемент в collection2.");
            Console.WriteLine("3. Удалить элемент в collection1.");
            Console.WriteLine("4. Удалить элемент в collection2.");
            Console.WriteLine("5. Изменить элемент в collection1.");
            Console.WriteLine("6. Изменить элемент в collection2.");
            Console.WriteLine("7. Просмотреть журналы.");
            Console.WriteLine("8. Просмотреть collection1.");
            Console.WriteLine("9. Просмотреть collection2.");
            Console.WriteLine("10. Выход.");
        }

        static void OutputJournals(Journal j1, Journal j2)
        {
            Console.WriteLine("Первый журнал:");
            j1.Print();
            Console.WriteLine("Второй журнал:");
            j2.Print();
        }

        //static void act(MySearchTree col, Journal j1, Journal j2)
        //{
        //    col.DeleteLeaf(col.top);
        //    col.PrintTree(col.top, 10);
        //    OutputJournals(j1, j2);
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Созданы две коллекции по 6 элементов. ");
            //Создаем две коллекции
            var collection1 = new MySearchTree(6, "collection1");
            var collection2 = new MySearchTree(6, "collection2");

            //создаем 2 журанала
            var journal1 = new Journal();
            var journal2 = new Journal();

            //подписываемся на события
            collection1.CollectionCountChanged += journal1.CollectionCountChanged;
            collection1.CollectionReferenceChanged += journal1.CollectionReferenceChanged;

            collection1.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
            collection2.CollectionReferenceChanged += journal2.CollectionReferenceChanged;



            //флаг
            bool endTheProgram = false;

            while(!endTheProgram)
            {
                Menu();
                int choice = CheckInput.ParseInt("Ваш выбор: ");
                switch(choice)
                {
                    case 1:
                        collection1.Add();
                        break;
                    case 2:
                        collection2.Add();
                        break;
                    case 3:
                        collection1.DeleteLeaf(collection1.top);
                        break;
                    case 4:
                        collection2.DeleteLeaf(collection2.top);
                        break;
                    case 5:
                        collection1.ExchangeLeaf(collection1.top);
                        break;
                    case 6:
                        collection2.ExchangeLeaf(collection2.top);
                        break;
                    case 7:
                        OutputJournals(journal1, journal2);
                        break;
                    case 8:
                        collection1.PrintTree(collection1.top, 10);
                        break;
                    case 9:
                        collection2.PrintTree(collection2.top, 10);
                        break;
                    case 10:
                        endTheProgram = true;
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет!");
                        break;
                }
            }
        }
    }
}

