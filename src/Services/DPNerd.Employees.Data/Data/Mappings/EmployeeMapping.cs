using DPNerd.Core.DomainObjects.ValueObjects;
using DPNerd.Employees.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Registration)
            .IsRequired()
            .HasColumnName("Matricula");

        builder.Property(e => e.Active)
            .IsRequired()
            .HasColumnName("Ativo");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar(250)");

        builder.OwnsOne(e => e.Cpf, tf =>
        {
            tf.Property(e => e.Number)
            .IsRequired()
            .HasMaxLength(Cpf.CpfMaxLength)
            .HasColumnName("Cpf")
            .HasColumnType($"varchar({Cpf.CpfMaxLength})");
        });

        builder.OwnsOne(e => e.Email, tf =>
        {
            tf.Property(e => e.EmailAddress)
            .IsRequired()
            .HasMaxLength(Email.EmailAddressMaxLength)
            .HasColumnName("Email")
            .HasColumnType($"varchar({Email.EmailAddressMaxLength})");
        });

        builder.HasOne(e => e.Address)
            .WithOne(e => e.Employee);

        builder.ToTable("Colaboradores");
    }
}
