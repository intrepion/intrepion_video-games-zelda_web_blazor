using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class WebSiteEtc : IEntityTypeConfiguration<WebSite>
{
    public void Configure(EntityTypeBuilder<WebSite> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedWebSites)
            .OnDelete(DeleteBehavior.Restrict);

        // EntityConfigurationCodePlaceholder
    }
}
