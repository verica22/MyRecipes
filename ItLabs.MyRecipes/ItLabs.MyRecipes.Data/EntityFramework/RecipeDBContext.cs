using System.Data.Entity;

namespace ItLabs.MyRecipes.Data
{
    public class RecipeDBContext : DbContext
    {
        public RecipeDBContext() : base("RecipeDBContext")
        {


        }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<RecipeIngredients> RecipeIngredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Recipe>().HasMany(i => i.Ingredients).WithMany(r => r.Recipes)
            //    .Map(t => t.MapLeftKey("RecipeId")
            //    .MapRightKey("IngredientsId")
            //    .ToTable("RecipeIngredients"));

            modelBuilder.Entity<Recipe>().HasMany(r => r.RecipeIngredients)
                .WithRequired(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId);
            modelBuilder.Entity<Ingredient>().HasMany(i => i.RecipeIngredients)
                .WithRequired(ri => ri.Ingredient)
                .HasForeignKey(ri => ri.IngredientsId);


        }
    }
}
