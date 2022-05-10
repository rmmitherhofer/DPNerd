using DPNerd.Employees.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;

public class VoterTitleMapping : IEntityTypeConfiguration<VoterTitle>
{
    public void Configure(EntityTypeBuilder<VoterTitle> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Number)
            .IsRequired()
            .HasColumnName("Numero");

        builder.Property(c => c.Zone)
            .IsRequired()
            .HasColumnName("Zona");

        builder.Property(c => c.Section)
            .IsRequired()
            .HasColumnName("Secao");

        builder.Property(c => c.EmployeeId)
            .IsRequired()
            .HasColumnName("ColaboradorId");

        builder.ToTable("TitulosDeEleitores");
    }
}
