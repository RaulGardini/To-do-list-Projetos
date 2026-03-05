using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");

        builder.HasKey(u => u.UsuarioId);

        builder.Property(u => u.UsuarioId)
            .HasColumnName("usuario_id");

        builder.Property(u => u.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(u => u.SenhaHash)
            .HasColumnName("senha_hash")
            .IsRequired();

        builder.Property(u => u.CriadoEm)
            .HasColumnName("criado_em");

        builder.HasIndex(u => u.Email).IsUnique();
    }
}