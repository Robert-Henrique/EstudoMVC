namespace Repository.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsuarioPermissaos", newName: "UsuarioPermissao");
            RenameColumn(table: "dbo.UsuarioPermissao", name: "Usuario_Id", newName: "UsuarioId");
            RenameColumn(table: "dbo.UsuarioPermissao", name: "Permissao_Id", newName: "PermissaoId");
            RenameIndex(table: "dbo.UsuarioPermissao", name: "IX_Usuario_Id", newName: "IX_UsuarioId");
            RenameIndex(table: "dbo.UsuarioPermissao", name: "IX_Permissao_Id", newName: "IX_PermissaoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UsuarioPermissao", name: "IX_PermissaoId", newName: "IX_Permissao_Id");
            RenameIndex(table: "dbo.UsuarioPermissao", name: "IX_UsuarioId", newName: "IX_Usuario_Id");
            RenameColumn(table: "dbo.UsuarioPermissao", name: "PermissaoId", newName: "Permissao_Id");
            RenameColumn(table: "dbo.UsuarioPermissao", name: "UsuarioId", newName: "Usuario_Id");
            RenameTable(name: "dbo.UsuarioPermissao", newName: "UsuarioPermissaos");
        }
    }
}
