
using OnData.PruebaTecnicaHDCBA.Models;
using System.Data.Entity;


namespace OnData.PruebaTecnicaHDCBA.Context
{
    public class StoreContext : DbContext
    {
        public virtual DbSet<type_containers> type_containers { get; set; }
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<containers> containers { get; set; }
        public virtual DbSet<containers_categories> containers_categories { get; set; }
    }
}