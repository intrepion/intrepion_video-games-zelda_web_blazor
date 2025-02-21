using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.VideoGames.Zelda.BusinessLogic.Data;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;

public static class PlaySessionImporter
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

        if (context.PlaySessions is null)
        {
            Console.WriteLine("Database table not found: context.PlaySessions");
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

        var records = csv.GetRecords<PlaySessionRecord>();

        var emulatorCoreList = await context.EmulatorCores.ToListAsync();
        var romList = await context.Roms.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var emulatorCore = emulatorCoreList.FirstOrDefault(x =>
                true
                && x.NormalizedName.Equals(record.EmulatorCore_NormalizedName)
            );

            var rom = romList.FirstOrDefault(x =>
                true
                && x.AlphanumericSha256Sum.Equals(record.Rom_AlphanumericSha256Sum)
            );

            // ManyToOneCodePlaceholder

            if (true
            // NullCheckCodePlaceholder
            )
            {
                var playSession = new PlaySession
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    EmulatorCore = emulatorCore,
                    EndDateTime = record.EndDateTime,
                    IsTest = record.IsTest,
                    Rom = rom,
                    StartDateTime = record.StartDateTime,
                    // NewEntityCodePlaceholder
                };

                var dbPlaySession = await context.PlaySessions.SingleOrDefaultAsync(
                    x => true
                    && x.StartDateTime.Equals(playSession.StartDateTime)
                    // CompositeKeyCodePlaceholder
                );

                if (dbPlaySession is null)
                {
                    await context.PlaySessions.AddAsync(playSession);
                }
                else
                {
                    dbPlaySession.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbPlaySession.UpdateDateTime = DateTime.UtcNow;

                    dbPlaySession.EmulatorCore = emulatorCore;
                    dbPlaySession.EndDateTime = record.EndDateTime;
                    dbPlaySession.IsTest = record.IsTest;
                    dbPlaySession.Rom = rom;
                    dbPlaySession.StartDateTime = record.StartDateTime;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
