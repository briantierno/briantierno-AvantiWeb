using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanti_MVC.Models
{
   public class ProductosService
    {
        private static ProductosRepository Repo = null;

       
        public static IQueryable<productos> ObtenerProductoPorCategoria(string categoria)
       
        {
            Repo = new ProductosRepository();

            return (from p in Repo.GetTable()
                    where p.Categoria == categoria
                    select p);
            
                    }

        public static Double ObtenerPrecioPorCategoria(string categoria)

        {
            Repo = new ProductosRepository();
            var producto = new productos();
               producto = (from p in Repo.GetTable() where p.Categoria == categoria select p).FirstOrDefault();
            
            return (producto.Precio);

        }


        public static void EliminarProducto(productos P)
        {
            Repo = new ProductosRepository();

            Repo.Delete(P);

            Repo.SubmitChanges();
        }



        public static void InsertarProducto(productos P)
        {
            Repo = new ProductosRepository();

            Repo.Insert(P);

            Repo.SubmitChanges();
        }

    }
}
