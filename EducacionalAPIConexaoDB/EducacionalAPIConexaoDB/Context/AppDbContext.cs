using EducacionalAPIConexaoDB.Models;
using Microsoft.EntityFrameworkCore;

namespace EducacionalAPIConexaoDB.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Educacional>? Educacionais { get; set; } 

        public DbSet<Aluno>? Alunos { get; set;}

        public DbSet<Turma>? Turmas { get; set; } 

        public DbSet<Falta>? Faltas { get; set; }

        public DbSet<Email>? Email { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder mb)
        //{
        //    mb.Entity<>
        //}
    }
}
