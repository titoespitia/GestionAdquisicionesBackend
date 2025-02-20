using GestionAdquisiciones.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionAdquisiciones.Infraestructura.Persistencia;

public class ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> opciones) : DbContext(opciones)
{
    public DbSet<Adquisicion> Adquisiciones => Set<Adquisicion>();
    public DbSet<HistorialAdquisicion> HistorialAdquisiciones => Set<HistorialAdquisicion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Adquisicion>(entidad =>
        {
            entidad.HasKey(a => a.Id);
            entidad.Property(a => a.Presupuesto).IsRequired();
            entidad.Property(a => a.UnidadAdministrativa).HasMaxLength(150).IsRequired();
            entidad.Property(a => a.TipoBienServicio).HasMaxLength(150).IsRequired();
            entidad.Property(a => a.Cantidad).IsRequired();
            entidad.Property(a => a.ValorUnitario).IsRequired();
            entidad.Property(a => a.FechaAdquisicion).IsRequired();
            entidad.Property(a => a.Proveedor).HasMaxLength(200).IsRequired();
            entidad.Property(a => a.Documentacion).HasMaxLength(500);
            entidad.Property(a => a.FechaCreacion).IsRequired();
            entidad.Property(a => a.FechaModificacion).IsRequired();

            entidad.HasMany<HistorialAdquisicion>()
                   .WithOne()
                   .HasForeignKey(h => h.AdquisicionId)
                   .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<HistorialAdquisicion>(entidad =>
        {
            entidad.HasKey(h => h.Id);
            entidad.Property(h => h.ModificadoPor).HasMaxLength(150).IsRequired();
            entidad.Property(h => h.FechaCambio).IsRequired();
            entidad.Property(h => h.CampoModificado).HasMaxLength(100).IsRequired();
            entidad.Property(h => h.ValorAnterior).HasMaxLength(500).IsRequired();
            entidad.Property(h => h.ValorNuevo).HasMaxLength(500).IsRequired();
        });
    }
}
