using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Avanti_MVC.Models
{
   public class ProductosRepository : BaseRepository<productos>
    {
        //Devuelve el pedido o NULL
        public productos ObtenerProductoPorID(int IdProducto)
        {
            return (from p in GetTable()
                    where p.Id_producto == IdProducto
                    select p).FirstOrDefault();
        }

        
        public void TruncarProductos() 
            
        {            
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE productos");
            DataContextManager.RefreshNew();
        }

    }
}
