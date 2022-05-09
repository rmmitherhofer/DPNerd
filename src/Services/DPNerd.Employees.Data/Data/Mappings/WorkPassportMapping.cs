using DPNerd.Employees.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;
public class WorkPassportMapping : IEntityTypeConfiguration<WorkPassport>
{
    public void Configure(EntityTypeBuilder<WorkPassport> builder)
    {
        builder.HasKey(w => new { w.Number, w.Serie });

        builder.Property(w => w.Number)
            .IsRequired()
            .HasColumnName("Numero");

        builder.Property(w => w.Serie)
           .IsRequired()
           .HasColumnName("Serie");

        builder.Property(w => w.State)
            .IsRequired()
            .HasColumnName("Emissor")
            .HasColumnType("varchar(2)");

        builder.Property(w => w.DispatchDate)
            .IsRequired()
            .HasColumnName("DataEmissao");

        builder.Property(c => c.EmployeeId)
            .IsRequired()
            .HasColumnName("ColaboradorId");

        builder.ToTable("CarteirasDeTrabalho");
    }
}
