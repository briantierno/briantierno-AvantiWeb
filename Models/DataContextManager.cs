using System;
using System.Linq;
using System.Configuration;

namespace Avanti_MVC.Models
{
    public class DataContextManager
    {
        [ThreadStaticAttribute]
        private static AvantiTestEntities _Context;

        public static AvantiTestEntities Context
        {
            get
            {
                if (DataContextManager._Context == null)

                    DataContextManager._Context = new AvantiTestEntities();
                
                return DataContextManager._Context;
            }
        }

        public static void RefreshNew()
        {
            if (DataContextManager._Context != null)
            {
                DataContextManager._Context.Dispose();
                DataContextManager._Context = null;
            }

            DataContextManager._Context = new AvantiTestEntities();
        }


        //public static void LocalContext()
        //{
        //    if (DataContextManager._Context != null)
        //    {
        //        DataContextManager._Context.Dispose();
        //        DataContextManager._Context = null;
        //    }

        //    DataContextManager._Context = new AvantiTestEntities("name=avantiEntitieslocal");
        //}



    }
}
