using DPNerd.Employees.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;

public class GeneralRecordMapping : IEntityTypeConfiguration<GeneralRecord>
{
    public void Configure(EntityTypeBuilder<GeneralRecord> builder)
    {
        builder.HasKey(c => c.Number);

        builder.Property(c => c.Number)
            .IsRequired()
            .HasColumnName("Numero")
            .HasColumnType("varchar(30)");

        builder.Property(c => c.IssuingAgency)
            .IsRequired()
            .HasColumnName("OrgaoEmissor")
            .HasColumnType("varchar(10)");

        builder.Property(c => c.DispatchDate)
            .IsRequired()
            .HasColumnName("DataEmissao");

        builder.Property(c => c.State)
            .IsRequired()
            .HasColumnName("Estado")
            .HasColumnType("varchar(2)");

        builder.Property(c => c.EmployeeId)
            .IsRequired()
            .HasColumnName("ColaboradorId");

        builder.ToTable("RegistrosGerais");
    }
}
