namespace Proj_SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Role");
        }
    }
}
