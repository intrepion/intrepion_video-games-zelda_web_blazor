using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class RomImporter
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

        if (context.Roms is null)
        {
            Console.WriteLine("Database table not found: context.Roms");
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

        var records = csv.GetRecords<RomRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
            // NullCheckCodePlaceholder
            )
            {
                var rom = new Rom
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    FileName = record.FileName,
                    NormalizedFileName = record.FileName.ToUpperInvariant(),
                    IsTest = record.IsTest,
                    Sha256Sum = record.Sha256Sum,
                    AlphanumericSha256Sum = new string(record.Sha256Sum.ToLowerInvariant().Where(char.IsLetterOrDigit).ToArray()),
                    // NewEntityCodePlaceholder
                };

                var dbRom = await context.Roms.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedFileName.Equals(rom.NormalizedFileName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbRom is null)
                {
                    await context.Roms.AddAsync(rom);
                }
                else
                {
                    dbRom.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbRom.UpdateDateTime = DateTime.UtcNow;

                    dbRom.FileName = record.FileName;
                    dbRom.IsTest = record.IsTest;
                    dbRom.Sha256Sum = record.Sha256Sum;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
