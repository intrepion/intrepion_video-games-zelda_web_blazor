using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class EmulatorCoreEtc : IEntityTypeConfiguration<EmulatorCore>
{
    public void Configure(EntityTypeBuilder<EmulatorCore> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedEmulatorCores)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Emulator)
            .WithMany(x => x.EmulatorCores)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
