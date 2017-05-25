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
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
               .HasMany<Permissao>(s => s.Permissoes)
               .WithMany(c => c.Usuarios)
               .Map(cs =>
               {
                   cs.MapLeftKey("UsuarioId");
                   cs.MapRightKey("PermissaoId");
                   cs.ToTable("UsuarioPermissao");
               });

            modelBuilder.Entity<Perfil>()
               .HasMany<Permissao>(s => s.Permissoes)
               .WithMany(c => c.Perfis)
               .Map(cs =>
               {
                   cs.MapLeftKey("PerfilId");
                   cs.MapRightKey("PermissaoId");
                   cs.ToTable("PerfilPermissao");
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}
