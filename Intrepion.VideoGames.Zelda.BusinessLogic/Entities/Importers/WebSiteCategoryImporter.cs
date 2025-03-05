using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class WebSiteCategoryImporter
{
    public static async Task ImportAsync(
       ApplicationDbContext context,
       string userName, string csvPath
    )
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine("File not found: " + csvPath);
            return;
        }

        if (context.WebSiteCategories is null)
        {
            Console.WriteLine("Database table not found: context.WebSiteCategories");
            return;
        }

        var normalizedUserName = userName.ToUpperInvariant();
        var applicationUserUpdatedBy = await context.Users.SingleOrDefaultAsync(x => x.NormalizedUserName != null && x.NormalizedUserName.Equals(normalizedUserName));

        if (applicationUserUpdatedBy is null)
        {
            Console.WriteLine("UserName not found: " + userName);
            return;
        }

        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture),
            Delimiter = "|",
        });

        var records = csv.GetRecords<WebSiteCategoryRecord>();

        var webSiteList = await context.WebSites.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var webSite = webSiteList.FirstOrDefault(x =>
                true
                && x.NormalizedName.Equals(record.WebSite_NormalizedName)
            );

            // ManyToOneCodePlaceholder

            if (true
            // NullCheckCodePlaceholder
            )
            {
                var webSiteCategory = new WebSiteCategory
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    IsTest = record.IsTest,
                    Name = record.Name,
                    NormalizedName = record.Name.ToUpperInvariant(),
                    WebSite = webSite,
                    // NewEntityCodePlaceholder
                };

                var dbWebSiteCategory = await context.WebSiteCategories.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName.Equals(webSiteCategory.NormalizedName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbWebSiteCategory is null)
                {
                    await context.WebSiteCategories.AddAsync(webSiteCategory);
                }
                else
                {
                    dbWebSiteCategory.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbWebSiteCategory.UpdateDateTime = DateTime.UtcNow;

                    dbWebSiteCategory.IsTest = record.IsTest;
                    dbWebSiteCategory.Name = record.Name;
                    dbWebSiteCategory.WebSite = webSite;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
