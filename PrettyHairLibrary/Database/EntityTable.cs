using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary.Database
{
    public class EntityTable
    {
        private EntityKeyGenerator keyGenerator;
        private IDictionary<int?, object> entities;
        [field: NonSerialized]
        public event
            EventHandler EntityTableItemAdded;
        [field: NonSerialized]
        public event
            EventHandler EntityTableRestored;
        internal EntityTable(EntityKeyGenerator keyGenerator)
        {
            this.keyGenerator = keyGenerator;
            entities = new Dictionary<int?, object>();
        }

        internal virtual object GetByKey(int? key)
        {
            return entities[key];
        }

        internal virtual ICollection<object> All {
            get {
                return entities.Values;
            }
        }

        internal virtual int? AddEntity(object value) {
            int? key = keyGenerator.NextKey;
            entities[key] = value;

            EntityAddedEventArgs args = new EntityAddedEventArgs();
            EntityTableItemAdded?.Invoke(this, args);
            return key;
        }

        internal virtual void Restore(EntityTable restoredTable) {
            entities.Clear();
            foreach(KeyValuePair<int?, object> pair in restoredTable.entities)
            {
                entities.Add(pair.Key, pair.Value);
            }
            EntityTableRestored?.Invoke(this, EventArgs.Empty);

        }
        public class EntityAddedEventArgs : EventArgs
        {
            public object objectAdded;
        }

    }

}
