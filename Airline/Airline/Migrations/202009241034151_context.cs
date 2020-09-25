namespace Airline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class context : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "Type");
        }
    }
}
