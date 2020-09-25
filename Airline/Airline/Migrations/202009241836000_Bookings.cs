namespace Airline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bookings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Uid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Uid");
        }
    }
}
