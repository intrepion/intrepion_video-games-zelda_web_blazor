using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class WebSiteCategoryEtc : IEntityTypeConfiguration<WebSiteCategory>
{
    public void Configure(EntityTypeBuilder<WebSiteCategory> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedWebSiteCategories)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.WebSite)
            .WithMany(x => x.WebSiteCategories)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
