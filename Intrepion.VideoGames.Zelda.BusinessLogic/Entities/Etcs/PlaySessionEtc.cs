using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class PlaySessionEtc : IEntityTypeConfiguration<PlaySession>
{
    public void Configure(EntityTypeBuilder<PlaySession> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedPlaySessions)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.EmulatorCore)
            .WithMany(x => x.PlaySessions)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Rom)
            .WithMany(x => x.PlaySessions)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
