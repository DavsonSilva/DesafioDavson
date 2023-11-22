using DesafioDavson.Controllers;
using DesafioDavson.Data.Map;
using DesafioDavson.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioDavson.Data
{
    public class SistemasDeTarefasDBContext : DbContext
    {
        public SistemasDeTarefasDBContext(DbContextOptions<SistemasDeTarefasDBContext> options) 
            : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
