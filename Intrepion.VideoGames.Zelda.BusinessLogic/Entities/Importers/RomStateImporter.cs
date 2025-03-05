using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class RomStateImporter
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

        if (context.RomStates is null)
        {
            Console.WriteLine("Database table not found: context.RomStates");
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

        var records = csv.GetRecords<RomStateRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
            // NullCheckCodePlaceholder
            )
            {
                var romState = new RomState
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    IsTest = record.IsTest,
                    Name = record.Name,
                    NormalizedName = record.Name.ToUpperInvariant(),
                    T = record.T,
                    X = record.X,
                    Y = record.Y,
                    Z = record.Z,
                    // NewEntityCodePlaceholder
                };

                var dbRomState = await context.RomStates.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName.Equals(romState.NormalizedName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbRomState is null)
                {
                    await context.RomStates.AddAsync(romState);
                }
                else
                {
                    dbRomState.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbRomState.UpdateDateTime = DateTime.UtcNow;

                    dbRomState.IsTest = record.IsTest;
                    dbRomState.Name = record.Name;
                    dbRomState.T = record.T;
                    dbRomState.X = record.X;
                    dbRomState.Y = record.Y;
                    dbRomState.Z = record.Z;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
