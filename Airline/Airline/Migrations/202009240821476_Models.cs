namespace Airline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        From = c.String(),
                        To = c.String(),
                        Seats = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        Seats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.Searches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsersId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UsersId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Searches");
            DropTable("dbo.Flights");
            DropTable("dbo.Bookings");
        }
    }
}
