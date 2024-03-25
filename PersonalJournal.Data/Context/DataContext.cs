using Microsoft.EntityFrameworkCore;
using PersonalJournal.Domain.Models;
using Stories.Data.Configuration;

namespace Stories.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Remimder> Remimder { get; set; }
        public DbSet<User> User { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GoalEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LevelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RemimderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NoteEntityConfiguration());
        }
    }
}