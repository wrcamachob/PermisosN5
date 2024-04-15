using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PermissionsN5;

public partial class PermissionContext : DbContext
{
    public PermissionContext()
    {
    }

    public PermissionContext(DbContextOptions<PermissionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HNG3HQ1;Database=Permission;Trusted_Connection=True;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.Property(e => e.Id).HasComment("Unique ID");
            entity.Property(e => e.ApellidoEmpleado).HasComment("Employee Surname");
            entity.Property(e => e.FechaPermiso).HasComment("Permission Granted on Date");
            entity.Property(e => e.NombreEmpleado).HasComment("Employee forename");
            entity.Property(e => e.TipoPermiso).HasComment("Permission Type");

            entity.HasOne(d => d.TipoPermisoNavigation).WithMany(p => p.Permisos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permisos_TipoPermisos");
        });

        modelBuilder.Entity<TipoPermiso>(entity =>
        {
            entity.Property(e => e.Id).HasComment("Unique ID");
            entity.Property(e => e.Descripcion).HasComment("Permission description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
