using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanti_MVC.Models
{

    public partial class pedidos
    {
        public string Nombrecliente
        {
            get { return clientes.Nombre; }

        }

        public string Telefonocliente
        {
            get { return clientes.Telefono; }

        }

        public string Direccioncliente
        {
            get { return clientes.Direccion; }

        }

        public string Observcliente
        {
            get { return clientes.Observaciones; }

        }


        public string NombreMotoquero
        {
            get { return motoqueros.Nombre; }

        }



        public DateTime Horacorta => new DateTime(Hora.Ticks);
              
    }

}

