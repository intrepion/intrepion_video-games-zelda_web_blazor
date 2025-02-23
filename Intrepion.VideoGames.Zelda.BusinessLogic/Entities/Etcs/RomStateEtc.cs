using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class RomStateEtc : IEntityTypeConfiguration<RomState>
{
    public void Configure(EntityTypeBuilder<RomState> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedRomStates)
            .OnDelete(DeleteBehavior.Restrict);

        // EntityConfigurationCodePlaceholder
    }
}
