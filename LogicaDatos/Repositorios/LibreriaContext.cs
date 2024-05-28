using LogicaNegocio.Dominio;
using LogicaNegocio.VOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Convierte "Email" de Usuario en un campo de tipo EmailUsuario (Value Object).
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasColumnName("Email")
                .HasConversion(
                    email => email.Valor,
                    valor => new EmailUsuario(valor)
                );

            //Vuelve a "Email" de Usuario un campo único.
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            //Vuelve a "Nombre" de Articulo un campo único.
            modelBuilder.Entity<Articulo>()
                .HasIndex(a => a.Nombre)
                .IsUnique();

            //Vuelve a "Codigo" de Articulo un campo único.
            modelBuilder.Entity<Articulo>()
                .HasIndex(a => a.Codigo)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=Papeleria; Integrated Security=SSPI;");
        }
    }
}
