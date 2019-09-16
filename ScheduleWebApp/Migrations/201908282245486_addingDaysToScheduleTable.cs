namespace ScheduleWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDaysToScheduleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "monday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "tuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "wednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "thursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "friday", c => c.Boolean(nullable: false));
            DropColumn("dbo.Schedules", "FirstShift");
            DropColumn("dbo.Schedules", "SecondShift");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "SecondShift", c => c.String());
            AddColumn("dbo.Schedules", "FirstShift", c => c.String());
            DropColumn("dbo.Schedules", "friday");
            DropColumn("dbo.Schedules", "thursday");
            DropColumn("dbo.Schedules", "wednesday");
            DropColumn("dbo.Schedules", "tuesday");
            DropColumn("dbo.Schedules", "monday");
        }
    }
}
