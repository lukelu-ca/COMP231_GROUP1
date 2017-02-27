using sRecipe.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace sRecipe.Domain.Concrete
{
        public class sRecipeContext : DbContext
    {
        // Your context has been configured to use a 'sRecipeContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'sRecipe.Domain.sRecipeContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'sRecipeContext' 
        // connection string in the application configuration file.
        public sRecipeContext()
            : base("name=sRecipeContext")
        {
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DbInitializer());

            //// Configure User & Profile entity
            //modelBuilder.Entity<User>()
            //            .HasOptional(s => s.Profile) // Mark Profile property optional in User entity
            //            .WithRequired(ad => ad.User); // mark Student property as required in Profile entity. Cannot save StudentAddress without Student
            base.OnModelCreating(modelBuilder);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<MadeIt> MadeIts { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<MadeItProcess> MadeItProcesses { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}