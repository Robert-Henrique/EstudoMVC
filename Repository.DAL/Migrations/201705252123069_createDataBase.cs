namespace Repository.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDataBase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PermissaoUsuario", newName: "UsuarioPermissao");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UsuarioPermissao", newName: "PermissaoUsuario");
        }
    }
}
