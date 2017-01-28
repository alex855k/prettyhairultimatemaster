using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary.Database
{
    public class EntityKeyGenerator
    {

        private static volatile EntityKeyGenerator instance;
        private Random r = null;

        private EntityKeyGenerator() {
            r= new Random();
        }
        public static EntityKeyGenerator Instance {
            get {
                if(instance == null)
                {
                    instance = new EntityKeyGenerator();
                }
                return instance;
            }
        }

       public virtual int NextKey
        {
            get { 
                int randomNb = r.Next(100, 9999);
                DateTime d = DateTime.Now;
                string timestamp = d.Day.ToString() +
                    d.Minute.ToString() + randomNb.ToString();
                randomNb = Convert.ToInt32(timestamp); 
                return randomNb;
            }
        }

    }
}
