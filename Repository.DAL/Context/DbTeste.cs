using Repository.DataModel;
using System.Data.Entity;

namespace Repository.DAL.Context
{
    public class DbTeste : DbContext
    {
        public DbTeste() : base("DbTeste") { }

        public DbSet<Area> Area { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
