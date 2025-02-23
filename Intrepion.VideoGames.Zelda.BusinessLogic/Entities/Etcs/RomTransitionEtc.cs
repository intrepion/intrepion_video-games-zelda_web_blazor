using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class RomTransitionEtc : IEntityTypeConfiguration<RomTransition>
{
    public void Configure(EntityTypeBuilder<RomTransition> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedRomTransitions)
            .OnDelete(DeleteBehavior.Restrict);

        // EntityConfigurationCodePlaceholder
    }
}
