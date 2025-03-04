using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;

public class WebSiteSubcategoryEtc : IEntityTypeConfiguration<WebSiteSubcategory>
{
    public void Configure(EntityTypeBuilder<WebSiteSubcategory> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedWebSiteSubcategories)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.WebSite)
            .WithMany(x => x.WebSiteSubcategories)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.WebSiteCategory)
            .WithMany(x => x.WebSiteSubcategories)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
