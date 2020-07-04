using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanti_MVC.Models
{
   public class MotoquerosService
    {
        private static MotoquerosRepository Repo = null;

        //tiene que ser una instancia nueva de "Motoqueres", no una obtenida desde la base        
        public static void InsertarMotoquero(motoqueros M)
        {
            Repo = new MotoquerosRepository();

            Repo.Insert(M);

            Repo.SubmitChanges();
        }

        public static void EliminarMotoquero(motoqueros M)
        {
            Repo = new MotoquerosRepository();

            Repo.Delete(M);

            Repo.SubmitChanges();
        }

        public static motoqueros ObtenerMotoquerosPorPatente(string patente)
        { 
            Repo = new MotoquerosRepository();

            return Repo.ObtenerMotoqueroPorPatente(patente).FirstOrDefault();
        }

        public static motoqueros ObtenerMotoquerosPorNombre(string nombre)
        {
            Repo = new MotoquerosRepository();

            return Repo.ObtenerMotoqueroPorNombre(nombre).FirstOrDefault();
        }

    }
}
