using System.Data.Entity;

namespace Avanti_MVC.Models
{
    public partial class  avantiTestEntities : DbContext
    {

        public avantiTestEntities(string StringConnections)
            : base(StringConnections)
        {
        }
    }
}
