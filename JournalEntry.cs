using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealLaba13
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }

        public string TypeOfChange { get; set; }

        public string ChangedObjectInfo { get; set; }

        public JournalEntry(string collectionName, string typeOfChange, string changedObjectInfo)
        {
            CollectionName = collectionName;
            TypeOfChange = typeOfChange;
            ChangedObjectInfo = changedObjectInfo;
        }

        public override string ToString()
        {
            return $"Коллекция: {CollectionName}; Тип изменения: {TypeOfChange}; Объект: {ChangedObjectInfo};";
        }
    }
}
