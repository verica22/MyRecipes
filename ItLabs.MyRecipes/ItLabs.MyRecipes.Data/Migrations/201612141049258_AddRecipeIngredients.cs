namespace ItLabs.MyRecipes.Data.Migrations
{
    using System.Data.Entity.Migrations;
    public partial class AddRecipeIngredients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "IngredientsId", "dbo.Ingredients");
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        RecipeId = c.Int(nullable: false),
                        IngredientsId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeId, t.IngredientsId })
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientsId, cascadeDelete: true);
            
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        RecipeId = c.Int(nullable: false),
                        IngredientsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeId, t.IngredientsId });
            
            DropForeignKey("dbo.RecipeIngredients", "IngredientsId", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes");
            DropTable("dbo.RecipeIngredients");
            AddForeignKey("dbo.RecipeIngredients", "IngredientsId", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
