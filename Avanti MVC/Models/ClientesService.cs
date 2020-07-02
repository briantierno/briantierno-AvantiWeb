using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanti_MVC.Models
{
    public class ClientesService
    {
        private static ClientesRepository Repo = null;

        //tiene que ser una instancia nueva de "clientes", no una obtenida desde la base        
        public static void InsertarCliente(clientes c)
        {
            Repo = new ClientesRepository();

            Repo.Insert(c);

            Repo.SubmitChanges();
        }

        public static void EliminarCliente(clientes c)
        {
            Repo = new ClientesRepository();

            Repo.Delete(c);

            Repo.SubmitChanges();
        }
        public static clientes ObtenerClientesPorTelefono(string telefono)
        {
            Repo = new ClientesRepository();

            return Repo.ObtenerClientePorTelefono(telefono).FirstOrDefault();
        }


    }

}
