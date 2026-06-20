using Apicola.Entities;
using Apicola.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Apicola.DataAccess
{
    public class DbDataAccess : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public virtual DbSet<Alimento> Alimentos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Ciudad> Ciudades { get; set; }
        public virtual DbSet<Colmena> Colmenas { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Curado_Alimentado> Curados_Alimentados { get; set; }
        public virtual DbSet<Curado_Medicamento> Curado_Medicamentos { get; set; }
        public virtual DbSet<DetalleCompra> DetallesCompras { get; set; }
        public virtual DbSet<Duenio> Duenios { get; set; }
        public virtual DbSet<Fecha> Fechas { get; set; }
        public virtual DbSet<Localidad> Localidades { get; set; }
        public virtual DbSet<Medicamento> Medicamentos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
