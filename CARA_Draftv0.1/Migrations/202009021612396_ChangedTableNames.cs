namespace CARA_Draftv0._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTableNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "CA_ROLES");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "CA_USUARIO_ROLES");
            RenameTable(name: "dbo.AspNetUsers", newName: "CA_USUARIO");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "CA_USUARIO_CLAIM");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "CA_USUARIO_LOGIN");
            RenameColumn(table: "dbo.CA_ROLES", name: "Id", newName: "PK_Roles");
            RenameColumn(table: "dbo.CA_USUARIO", name: "Id", newName: "PK_Usuario");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.CA_USUARIO", name: "PK_Usuario", newName: "Id");
            RenameColumn(table: "dbo.CA_ROLES", name: "PK_Roles", newName: "Id");
            RenameTable(name: "dbo.CA_USUARIO_LOGIN", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.CA_USUARIO_CLAIM", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.CA_USUARIO", newName: "AspNetUsers");
            RenameTable(name: "dbo.CA_USUARIO_ROLES", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.CA_ROLES", newName: "AspNetRoles");
        }
    }
}
