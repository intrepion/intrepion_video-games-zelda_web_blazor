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

        builder.HasOne(x => x.PreviousRomState)
            .WithMany(x => x.PreviousRomTransitions)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.RomInput)
            .WithMany(x => x.RomTransitions)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.RomState)
            .WithMany(x => x.RomTransitions)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
