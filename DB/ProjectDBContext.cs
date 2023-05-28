using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DB
{
    public class ProjectDBContext : IdentityDbContext<IdentityUser>
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
            : base(options)
        {
                
         }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Nutricionist> Nutricionists { get; set; }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
       
 