using DPNerd.Employees.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;

public class ReservistMapping : IEntityTypeConfiguration<Reservist>
{
    public void Configure(EntityTypeBuilder<Reservist> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Number)
            .IsRequired()
            .HasColumnName("Numero");

        builder.Property(c => c.EnlistmentRegistration)
            .IsRequired()
            .HasColumnName("RegistroAlistamento");

        builder.Property(c => c.Serie)
            .IsRequired()
            .HasColumnName("Serie")
            .HasColumnType("varchar(1)");

        builder.Property(c => c.EmployeeId)
            .IsRequired()
            .HasColumnName("ColaboradorId");

        builder.ToTable("Reservistas");
    }
}
