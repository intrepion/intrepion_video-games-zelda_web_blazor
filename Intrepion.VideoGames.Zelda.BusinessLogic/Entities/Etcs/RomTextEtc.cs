using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class RomTextEtc : IEntityTypeConfiguration<RomText>
{
    public void Configure(EntityTypeBuilder<RomText> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedRomTexts)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RomState)
            .WithMany(x => x.RomTexts)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
