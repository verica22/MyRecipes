namespace ItLabs.MyRecipes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingColumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RecipeIngredients", name: "IngredientsId", newName: "IngredientId");
            //RenameIndex(table: "dbo.RecipeIngredients", name: "IX_IngredientsId", newName: "IX_IngredientId");
            AddColumn("dbo.Recipes", "IsDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "IsFavorite", c => c.Boolean(nullable: false));
            DropColumn("dbo.Recipes", "Done");
            DropColumn("dbo.Recipes", "Favorites");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Favorites", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "Done", c => c.Boolean(nullable: false));
            DropColumn("dbo.Recipes", "IsFavorite");
            DropColumn("dbo.Recipes", "IsDone");
            //RenameIndex(table: "dbo.RecipeIngredients", name: "IX_IngredientId", newName: "IX_IngredientsId");
            RenameColumn(table: "dbo.RecipeIngredients", name: "IngredientId", newName: "IngredientsId");
        }
    }
}
