using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Configurations;

public class TarefaProjetoConfiguration : IEntityTypeConfiguration<TarefaProjeto>
{
    public void Configure(EntityTypeBuilder<TarefaProjeto> builder)
    {
        builder.ToTable("tarefas");

        builder.HasKey(t => t.TarefaId);

        builder.Property(t => t.TarefaId)
            .HasColumnName("tarefa_id")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.ProjetoId)
            .HasColumnName("projeto_id");

        builder.Property(t => t.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("char(1)")
            .IsRequired();

        builder.Property(t => t.Tipo)
            .HasColumnName("tipo")
            .HasMaxLength(50);

        builder.Property(t => t.Obs)
            .HasColumnName("obs")
            .HasMaxLength(500);

        builder.Property(t => t.DataInicio)
            .HasColumnName("data_inicio");

        builder.Property(t => t.DataFinal)
            .HasColumnName("data_final");
    }
}