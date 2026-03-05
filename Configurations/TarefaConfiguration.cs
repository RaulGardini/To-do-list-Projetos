using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Configurations;

public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("tarefas");

        builder.HasKey(t => t.TarefaId);

        builder.Property(t => t.TarefaId)
            .HasColumnName("tarefa_id")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.UsuarioId)
            .HasColumnName("usuario_id");

        builder.Property(t => t.NomeTarefa)
            .HasColumnName("nome_tarefa")
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("char(1)")
            .IsRequired();

        builder.Property(t => t.CriadoEm)
            .HasColumnName("criado_em");
    }
}