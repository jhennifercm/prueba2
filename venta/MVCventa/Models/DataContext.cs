using System.Data.Entity;

namespace MVCventa.Models
{
    public class DataContext:DbContext

    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<MVCventa.Models.Vent> Vents { get; set; }
    }
}