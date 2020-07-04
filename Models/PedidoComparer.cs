using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanti_MVC.Models
{
    public class PedidoComparer : IEqualityComparer<pedidos>
    {
        public bool Equals(pedidos x, pedidos y)
        {
            if (x.PedidoN == y.PedidoN)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(pedidos obj)
        {
            return obj.PedidoN.GetHashCode();
        }
    }
}
