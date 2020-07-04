using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanti_MVC.Models
{
    public class MotoquerosRepository : BaseRepository<motoqueros>



    {
        public IQueryable<motoqueros> ObtenerMotoqueroPorPatente(string patente)
            {
            return (from c in GetTable()
                    where c.Patente.Contains(patente)
                    select c);
        }

            

    public IQueryable<motoqueros> ObtenerMotoqueroPorNombre(string nombre)
    {
        return (from c in GetTable()
                where c.Nombre.Contains(nombre)
                select c);
    }
}
}

    
