using DPNerd.Core.DomainObjects.ValueObjects;
using DPNerd.Employees.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;
public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(ec => ec.Id);

        builder.Property(ec => ec.Type)
            .IsRequired()
            .HasColumnName("Tipo");

        builder.Property(ec => ec.Description)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType("varchar(40)");

        builder.OwnsOne(ec => ec.Email, ece =>
        {
            ece.Property(e => e.EmailAddress)
                .HasMaxLength(Email.EmailAddressMaxLength)
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.EmailAddressMaxLength})");
        });

        builder.Property(ec => ec.Phone)
            .HasMaxLength(15)
            .HasColumnName("Numero")
            .HasColumnType("varchar(15)");

        builder.Property(c => c.EmployeeId)
            .IsRequired()
            .HasColumnName("ColaboradorId");

        builder.ToTable("Contatos");
    }
}
