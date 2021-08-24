namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Brands", newName: "tblBrand");
            RenameTable(name: "dbo.Categories", newName: "tblCategory");
            RenameTable(name: "dbo.Products", newName: "tblProduct");
            AlterColumn("dbo.tblProduct", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProduct", "Name", c => c.String());
            RenameTable(name: "dbo.tblProduct", newName: "Products");
            RenameTable(name: "dbo.tblCategory", newName: "Categories");
            RenameTable(name: "dbo.tblBrand", newName: "Brands");
        }
    }
}
