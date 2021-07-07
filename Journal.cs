using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealLaba13
{
    public class Journal
    {
        public List<JournalEntry> EventsList { get; set; } = new List<JournalEntry>();

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry newEntry = new JournalEntry(args.CollectionName, args.NameOfChange, args.Element.ToString());
            EventsList.Add(newEntry);
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry newEntry = new JournalEntry(args.CollectionName, args.NameOfChange, args.Element.ToString());
            EventsList.Add(newEntry);
        }

        public void Print()
        {
            foreach (var el in EventsList)
            {
                Console.WriteLine(el);
            }
        }
    }
}
