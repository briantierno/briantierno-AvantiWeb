using System.Linq;

namespace Avanti_MVC.Models
{
    public class ClientesRepository : BaseRepository<clientes>
    {
        public IQueryable<clientes> ObtenerClientePorTelefono(string telefono)
        {
            return (from c in GetTable()
                        where c.Telefono == telefono
                        select c); 
        }

                      
    }
}
