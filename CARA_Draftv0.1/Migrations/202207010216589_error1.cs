namespace CARA_Draftv0._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CA_USUARIO", "ProfileImgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CA_USUARIO", "ProfileImgPath");
        }
    }
}
