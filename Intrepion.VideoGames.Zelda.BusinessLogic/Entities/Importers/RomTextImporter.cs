using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class RomTextImporter
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

        if (context.RomTexts is null)
        {
            Console.WriteLine("Database table not found: context.RomTexts");
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

        var records = csv.GetRecords<RomTextRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var romText = new RomText
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    IsTest = record.IsTest,
                    Name = record.Name,
                    NormalizedName = record.Name.ToUpperInvariant(),
                    // NewEntityCodePlaceholder
                };

                var dbRomText = await context.RomTexts.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName.Equals(romText.NormalizedName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbRomText is null)
                {
                    await context.RomTexts.AddAsync(romText);
                }
                else
                {
                    dbRomText.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbRomText.UpdateDateTime = DateTime.UtcNow;

                    dbRomText.IsTest = record.IsTest;
                    dbRomText.Name = record.Name;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
