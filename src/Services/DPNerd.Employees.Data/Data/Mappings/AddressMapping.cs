using DPNerd.Employees.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.PublicPlace)
            .IsRequired()
            .HasColumnName("Logradouro")
            .HasColumnType("varchar(400)");

        builder.Property(c => c.Number)
            .IsRequired()
            .HasColumnName("Numero")
            .HasColumnType("varchar(10)");

        builder.Property(c => c.ZipCode)
            .IsRequired()
            .HasColumnName("CEP")
            .HasColumnType("varchar(20)");

        builder.Property(c => c.Complement)
            .HasColumnName("Complemento")
            .HasColumnType("varchar(550)");

        builder.Property(c => c.District)
            .IsRequired()
            .HasColumnName("Bairro")
            .HasColumnType("varchar(250)");

        builder.Property(c => c.City)
            .IsRequired()
            .HasColumnName("Cidade")
            .HasColumnType("varchar(250)");

        builder.Property(c => c.State)
            .IsRequired()
            .HasColumnName("Estado")
            .HasColumnType("varchar(95)");

        builder.ToTable("Enderecos");
    }
}
