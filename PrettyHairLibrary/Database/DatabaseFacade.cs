using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary.Database
{
    public class DatabaseFacade
    {
        private static volatile DatabaseFacade instance; 
        
        public static DatabaseFacade Instance
        {
            get {
                if (Instance == null) {
                    instance = new DatabaseFacade();
                        }
                return instance;

            }
        }
        //instance variables
        private EntityTable engines;
        //private AbstractEntityPersistenceStrategy persistenceStrategy;
        public event EventHandler EngineAdded;
        public event EventHandler EnginesRestored;

        //private constructor
        private DatabaseFacade() {
            engines = new EntityTable(EntityKeyGenerator.Instance);
           // engines.EntityTableItemAdded += HandleEngineAdded;
            //engines.EntityTableRestored += HandleEngineRestored;

            // Set strategy
            //persistenceStrategy = new EntitySerializationStrategy();

        }
    }
}
