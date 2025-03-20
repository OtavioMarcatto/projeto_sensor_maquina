using Microsoft.EntityFrameworkCore;
using ProjetoSensor.Models;

namespace ProjetoSensor.Data;

public class ProjetoSensorContext(DbContextOptions<ProjetoSensorContext> options)
    : DbContext(options)
{
    public DbSet<MedicaoCorrente> Medicoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MedicaoCorrente>(entity =>
        {
            entity.ToTable("medicao_corrente");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entity.Property(e => e.ValorCorrente).HasColumnName("valor_corrente");

            entity
                .Property(e => e.DataHora)
                .HasColumnName("data_hora")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
        });
    }
}
