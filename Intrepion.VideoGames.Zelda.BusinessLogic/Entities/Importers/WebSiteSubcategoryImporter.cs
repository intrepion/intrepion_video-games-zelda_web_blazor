using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class WebSiteSubcategoryImporter
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

        if (context.WebSiteSubcategories is null)
        {
            Console.WriteLine("Database table not found: context.WebSiteSubcategories");
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

        var records = csv.GetRecords<WebSiteSubcategoryRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var webSiteSubcategory = new WebSiteSubcategory
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    IsTest = record.IsTest,
                    Name = record.Name,
                    NormalizedName = record.Name.ToUpperInvariant(),
                    // NewEntityCodePlaceholder
                };

                var dbWebSiteSubcategory = await context.WebSiteSubcategories.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName.Equals(webSiteSubcategory.NormalizedName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbWebSiteSubcategory is null)
                {
                    await context.WebSiteSubcategories.AddAsync(webSiteSubcategory);
                }
                else
                {
                    dbWebSiteSubcategory.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbWebSiteSubcategory.UpdateDateTime = DateTime.UtcNow;

                    dbWebSiteSubcategory.IsTest = record.IsTest;
                    dbWebSiteSubcategory.Name = record.Name;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
