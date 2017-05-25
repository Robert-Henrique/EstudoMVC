namespace Repository.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PermissaoPerfils", newName: "PerfilPermissao");
            RenameColumn(table: "dbo.PerfilPermissao", name: "Permissao_Id", newName: "PermissaoId");
            RenameColumn(table: "dbo.PerfilPermissao", name: "Perfil_Id", newName: "PerfilId");
            RenameIndex(table: "dbo.PerfilPermissao", name: "IX_Perfil_Id", newName: "IX_PerfilId");
            RenameIndex(table: "dbo.PerfilPermissao", name: "IX_Permissao_Id", newName: "IX_PermissaoId");
            DropPrimaryKey("dbo.PerfilPermissao");
            AddPrimaryKey("dbo.PerfilPermissao", new[] { "PerfilId", "PermissaoId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PerfilPermissao");
            AddPrimaryKey("dbo.PerfilPermissao", new[] { "Permissao_Id", "Perfil_Id" });
            RenameIndex(table: "dbo.PerfilPermissao", name: "IX_PermissaoId", newName: "IX_Permissao_Id");
            RenameIndex(table: "dbo.PerfilPermissao", name: "IX_PerfilId", newName: "IX_Perfil_Id");
            RenameColumn(table: "dbo.PerfilPermissao", name: "PerfilId", newName: "Perfil_Id");
            RenameColumn(table: "dbo.PerfilPermissao", name: "PermissaoId", newName: "Permissao_Id");
            RenameTable(name: "dbo.PerfilPermissao", newName: "PermissaoPerfils");
        }
    }
}
