namespace ItLabs.MyRecipes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Ingredients", "DateModified", c => c.DateTime());
            AddColumn("dbo.Recipes", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Recipes", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "DateModified");
            DropColumn("dbo.Recipes", "DateCreated");
            DropColumn("dbo.Ingredients", "DateModified");
            DropColumn("dbo.Ingredients", "DateCreated");
        }
    }
}
