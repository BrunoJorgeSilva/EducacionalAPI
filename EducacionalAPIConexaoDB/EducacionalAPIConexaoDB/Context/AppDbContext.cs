using EducacionalAPIConexaoDB.Models;
using Microsoft.EntityFrameworkCore;

namespace EducacionalAPIConexaoDB.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Educational>? Educationals { get; set; } 

        public DbSet<Student>? Students { get; set;}

        public DbSet<Classroom>? ClassRooms { get; set; } 

        public DbSet<Lack>? Lacks { get; set; }

        public DbSet<Email>? Email { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder mb)
        //{
        //    mb.Entity<>
        //}
    }
}
