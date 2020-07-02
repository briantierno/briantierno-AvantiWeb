using System;
using System.Linq;


namespace Avanti_MVC.Models
   
{
    public class PedidoRepository : BaseRepository<pedidos>
    {
        //Devuelve el pedido o NULL
        public pedidos ObtenerPedidoPorID(int IdPedido)
        {
            return (from p in GetTable()
                        where p.ID_pedido == IdPedido
                        select p).FirstOrDefault(); 
        }

        public pedidos ObtenerPedidoPorTelefono(string telefono)
        {
            return (from p in GetTable()
                    where p.Telefonocliente == telefono
                    select p).FirstOrDefault();
        }

        public IQueryable<pedidos> ObtenerPedidosPorFechaYHora(DateTime fecha, TimeSpan desde, TimeSpan hasta)
        {
            DateTime fechaSinHora = fecha.Date;
           
            return (from p in GetTable()
                    where (p.Fecha) == fechaSinHora
                            && p.Hora >= desde && p.Hora <= hasta
                    select p).Distinct() ;
        }

        public IQueryable<pedidos> ObtenerPedidosPorFechaYHoraUnion(DateTime fecha, TimeSpan desde, TimeSpan hasta, DateTime fecha2, TimeSpan desde2, TimeSpan hasta2)
        {
            return ObtenerPedidosPorFechaYHora(fecha, desde, hasta).Union(ObtenerPedidosPorFechaYHora(fecha2, desde2, hasta2));
        }
    }
}
