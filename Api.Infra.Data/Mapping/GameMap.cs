using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mapping
{
    public class GameMap : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(g => g.Id);

            builder.HasIndex(g => g.Name)
                .IsUnique();
                
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}