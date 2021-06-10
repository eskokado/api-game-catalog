using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mapping
{
    public class StarMap : IEntityTypeConfiguration<StarEntity>
    {
        public void Configure(EntityTypeBuilder<StarEntity> builder)
        {
            builder.ToTable("Stars");

            builder.HasKey(s => new { s.PlayerId, s.GameId });

            builder.HasOne<PlayerEntity>(s => s.Player)
                .WithMany(p => p.Stars)
                .HasForeignKey(s => s.PlayerId);


            builder.HasOne<GameEntity>(s => s.Game)
                .WithMany(g => g.Stars)
                .HasForeignKey(s => s.GameId);
        }
    }
}