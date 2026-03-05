using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Configurations;

public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
{
    public void Configure(EntityTypeBuilder<Projeto> builder)
    {
        builder.ToTable("projetos");

        builder.HasKey(p => p.ProjetoId);

        builder.Property(p => p.ProjetoId)
            .HasColumnName("projeto_id")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasColumnType("char(1)")
            .IsRequired();

        builder.Property(p => p.FrontStack)
            .HasColumnName("front_stack")
            .HasMaxLength(200);

        builder.Property(p => p.FrontObs)
            .HasColumnName("front_obs")
            .HasMaxLength(500);

        builder.Property(p => p.BackStack)
            .HasColumnName("back_stack")
            .HasMaxLength(200);

        builder.Property(p => p.BackObs)
            .HasColumnName("back_obs")
            .HasMaxLength(500);

        builder.Property(p => p.BancoDeDados)
            .HasColumnName("banco_de_dados")
            .HasMaxLength(200);

        builder.Property(p => p.BancoDeDadosObs)
            .HasColumnName("banco_de_dados_obs")
            .HasMaxLength(500);

        builder.Property(p => p.DataInicio)
            .HasColumnName("data_inicio");

        builder.Property(p => p.DataFinal)
            .HasColumnName("data_final");

        builder.Property(p => p.UsuarioId)
            .HasColumnName("usuario_id");

        builder.Property(p => p.Obs)
            .HasColumnName("obs")
            .HasMaxLength(500);
    }
}