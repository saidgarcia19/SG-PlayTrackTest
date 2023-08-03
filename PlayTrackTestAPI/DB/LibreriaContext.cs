using Microsoft.EntityFrameworkCore;

namespace PlayTrackTestAPI.DB
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Autores> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libros>()
            .HasKey(l => l.LibroID);

            modelBuilder.Entity<Autores>()
                .HasKey(a => a.AutorID);

            modelBuilder.Entity<Categorias>()
                .HasKey(c => c.CategoriaID);

            modelBuilder.Entity<Libros>()
                .HasOne(l => l.Autor)
                .WithMany()
                .HasForeignKey(l => l.AutorID);

            modelBuilder.Entity<Libros>()
                .HasOne(l => l.Categoria)
                .WithMany()
                .HasForeignKey(l => l.CategoriaID);
        }
    }
}
