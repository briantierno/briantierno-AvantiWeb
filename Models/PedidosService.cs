using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Avanti_MVC.Models
{
    public class PedidosService
    {
        private static PedidoRepository Repo = null;


        public static void InsertarPedido(pedidos p)
        {
            Repo = new PedidoRepository();

            Repo.Insert(p);

            Repo.SubmitChanges();
        }

        public static void EliminarPedido(pedidos p)
        {
            Repo = new PedidoRepository();

            Repo.Delete(p);

            Repo.SubmitChanges();
        }


        public static IQueryable<pedidos> ObtenerPedidosSegunHorariosLocal()
        {
            Repo = new PedidoRepository();

            DateTime fechaYhoraActual = DateTime.Now;
            DateTime fechaYhoraMenos1Dia = DateTime.Now.AddDays(-1);            

            if (TimeBetween(fechaYhoraActual, new TimeSpan(0, 0, 0), new TimeSpan(05, 59, 0)))
            {                
                return Repo.ObtenerPedidosPorFechaYHoraUnion(fechaYhoraMenos1Dia, new TimeSpan(18,00,00),new TimeSpan(23, 59, 00),
                                                                fechaYhoraActual, new TimeSpan(00, 00, 00), new TimeSpan(06, 00, 00));
            }
            else
            {
                if (TimeBetween(fechaYhoraActual, new TimeSpan(06, 0, 0), new TimeSpan(17, 59, 0)))
                    return Repo.ObtenerPedidosPorFechaYHora(fechaYhoraActual, new TimeSpan(06, 00, 00), new TimeSpan(17, 59, 00));
                else
                    return Repo.ObtenerPedidosPorFechaYHora(fechaYhoraActual, new TimeSpan(18, 00, 00), new TimeSpan(23, 59, 00));
            }

            
        }

        public static bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
        {
            //convert datetime to a TimeSpan
            TimeSpan now = datetime.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }




    }

    
}
