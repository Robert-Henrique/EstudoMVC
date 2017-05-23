using Repository.DataModel;
using System.Data.Entity;

namespace Repository.DAL.Context
{
    public class DbTeste : DbContext
    {
        public DbTeste() : base("DbTeste") { }

        public DbSet<Area> Clientes { get; set; }
    }
}
