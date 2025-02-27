using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class EmulatorCoreImporter
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

        if (context.EmulatorCores is null)
        {
            Console.WriteLine("Database table not found: context.EmulatorCores");
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

        var records = csv.GetRecords<EmulatorCoreRecord>();

        var emulatorList = await context.Emulators.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var emulator = emulatorList.FirstOrDefault(x =>
                true
                && x.NormalizedName.Equals(record.Emulator_NormalizedName)
            );

            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var emulatorCore = new EmulatorCore
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    Emulator = emulator,
                    IsTest = record.IsTest,
                    Name = record.Name,
                    NormalizedName = record.Name.ToUpperInvariant(),
                    // NewEntityCodePlaceholder
                };

                var dbEmulatorCore = await context.EmulatorCores.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName.Equals(emulatorCore.NormalizedName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbEmulatorCore is null)
                {
                    await context.EmulatorCores.AddAsync(emulatorCore);
                }
                else
                {
                    dbEmulatorCore.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbEmulatorCore.UpdateDateTime = DateTime.UtcNow;

                    dbEmulatorCore.Emulator = emulator;
                    dbEmulatorCore.IsTest = record.IsTest;
                    dbEmulatorCore.Name = record.Name;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
