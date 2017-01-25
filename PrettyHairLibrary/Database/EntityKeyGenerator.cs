using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary.Database
{
    [Serializable]
    public class EntityKeyGenerator
    {

        private static volatile EntityKeyGenerator instance;

        private EntityKeyGenerator() { }
        public static EntityKeyGenerator Instance {
            get {
                if(instance == null)
                {
                    instance = new EntityKeyGenerator();
                }
                return instance;
            }
        }
        private int nextKey;

        public virtual int NextKey
        {
            get
            {
                Random r = new Random();
                int randomNb = r.Next(1, 1000);
                DateTime d = DateTime.Now;
                return randomNb + d.Year + d.Day + d.Hour + d.Minute + d.Second + d.Millisecond;
            }
        }

    }
}
