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

        var previousRomStateList = await context.RomStates.ToListAsync();
        var romInputList = await context.RomInputs.ToListAsync();
        var romStateList = await context.RomStates.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var previousRomState = previousRomStateList.FirstOrDefault(x =>
                true
                && x.NormalizedName.Equals(record.PreviousRomState_NormalizedName)
            );

            var romInput = romInputList.FirstOrDefault(x =>
                true
                && x.NormalizedName.Equals(record.RomInput_NormalizedName)
            );

            var romState = romStateList.FirstOrDefault(x =>
                true
                && x.NormalizedName.Equals(record.RomState_NormalizedName)
            );

            // ManyToOneCodePlaceholder

            if (true
                && previousRomState is not null
                && romInput is not null
                && romState is not null
            // NullCheckCodePlaceholder
            )
            {
                var romTransition = new RomTransition
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    IsTest = record.IsTest,
                    PreviousRomState = previousRomState,
                    RomInput = romInput,
                    RomState = romState,
                    // NewEntityCodePlaceholder
                };

                var dbRomTransition = await context.RomTransitions.SingleOrDefaultAsync(
                    x => true
                    && x.PreviousRomState != null && x.PreviousRomState.Equals(previousRomState)
                    && x.RomInput != null && x.RomInput.Equals(romInput)
                    && x.RomState != null && x.RomState.Equals(romState)
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
                    dbRomTransition.PreviousRomState = previousRomState;
                    dbRomTransition.RomInput = romInput;
                    dbRomTransition.RomState = romState;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
