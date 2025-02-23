using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class RomTransitionImporter
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

        if (context.RomTransitions is null)
        {
            Console.WriteLine("Database table not found: context.RomTransitions");
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

        var records = csv.GetRecords<RomTransitionRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var romTransition = new RomTransition
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    IsTest = record.IsTest,
                    Name = record.Name,
                    NormalizedName = record.Name.ToUpperInvariant(),
                    // NewEntityCodePlaceholder
                };

                var dbRomTransition = await context.RomTransitions.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName.Equals(romTransition.NormalizedName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbRomTransition is null)
                {
                    await context.RomTransitions.AddAsync(romTransition);
                }
                else
                {
                    dbRomTransition.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbRomTransition.UpdateDateTime = DateTime.UtcNow;

                    dbRomTransition.IsTest = record.IsTest;
                    dbRomTransition.Name = record.Name;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
