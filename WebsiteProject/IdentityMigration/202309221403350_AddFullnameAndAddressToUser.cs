﻿namespace WebsiteProject.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullnameAndAddressToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
    }
}
