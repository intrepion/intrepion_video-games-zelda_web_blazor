using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class RomEtc : IEntityTypeConfiguration<Rom>
{
    public void Configure(EntityTypeBuilder<Rom> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedRoms)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.GameConsole)
            .WithMany(x => x.Roms)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.WebSiteSubcategory)
            .WithMany(x => x.Roms)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
