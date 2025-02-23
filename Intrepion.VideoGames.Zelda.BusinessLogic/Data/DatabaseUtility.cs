using Intrepion.VideoGames.Zelda.BusinessLogic.Entities;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Importers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Data;

public static class DatabaseUtility
{
    public static async Task EnsureDbCreatedAndSeedAsync(
        IServiceProvider serviceProvider
    )
    {
        using var scope = serviceProvider.CreateScope();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var isNewDatabase = await applicationDbContext.Database.EnsureCreatedAsync();

        var adminName = "Admin";
        var adminUserPass = adminName + "1@Intrepion.VideoGames.Zelda.com";
        var adminNormalizedUserName = adminUserPass.ToUpperInvariant();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (isNewDatabase)
        {
            var adminUser = (await applicationDbContext.Users.AddAsync(new ApplicationUser
            {
                Email = adminUserPass,
                EmailConfirmed = true,
                NormalizedEmail = adminUserPass.ToUpperInvariant(),
                NormalizedUserName = adminUserPass.ToUpperInvariant(),
                UserName = adminUserPass,
            })).Entity;

            await userManager.AddPasswordAsync(adminUser, adminUserPass);

            var adminRole = (await applicationDbContext.Roles.AddAsync(new ApplicationRole
            {
                Name = adminName,
                NormalizedName = adminName.ToUpperInvariant(),
            })).Entity;

            adminRole.ApplicationUserUpdatedBy = adminUser;
            adminUser.ApplicationUserUpdatedBy = adminUser;
            _ = await applicationDbContext.UserRoles.AddAsync(new ApplicationUserRole
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id,
                ApplicationUserUpdatedBy = adminUser,
            });

            // ReadDataCodePlaceholder

            // await FakeData.SeedAsync(applicationDbContext, adminUser);

            await applicationDbContext.SaveChangesAsync();
        }

        var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

        var dataPath = @$"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}.data{Path.DirectorySeparatorChar}";

        var applicationRoleFileName = @$"{dataPath}ApplicationRole.csv";
        var applicationRoleCsvFilePath = Path.Combine(baseDirectoryPath, applicationRoleFileName);
        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);

        var applicationUserRoleFileName = @$"{dataPath}ApplicationUserRole.csv";
        var applicationUserRoleCsvFilePath = Path.Combine(baseDirectoryPath, applicationUserRoleFileName);
        await ApplicationUserRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserRoleCsvFilePath);

        var applicationUserFileName = @$"{dataPath}ApplicationUser.csv";
        var applicationUserCsvFilePath = Path.Combine(baseDirectoryPath, applicationUserFileName);
        await ApplicationUserImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserCsvFilePath);

        var companyFileName = @$"{dataPath}Company.csv";
        var companyCsvFilePath = Path.Combine(baseDirectoryPath, companyFileName);
        await CompanyImporter.ImportAsync(applicationDbContext, adminUserPass, companyCsvFilePath);

        var emulatorFileName = @$"{dataPath}Emulator.csv";
        var emulatorCsvFilePath = Path.Combine(baseDirectoryPath, emulatorFileName);
        await EmulatorImporter.ImportAsync(applicationDbContext, adminUserPass, emulatorCsvFilePath);

        var emulatorCoreFileName = @$"{dataPath}EmulatorCore.csv";
        var emulatorCoreCsvFilePath = Path.Combine(baseDirectoryPath, emulatorCoreFileName);
        await EmulatorCoreImporter.ImportAsync(applicationDbContext, adminUserPass, emulatorCoreCsvFilePath);

        var gameConsoleFileName = @$"{dataPath}GameConsole.csv";
        var gameConsoleCsvFilePath = Path.Combine(baseDirectoryPath, gameConsoleFileName);
        await GameConsoleImporter.ImportAsync(applicationDbContext, adminUserPass, gameConsoleCsvFilePath);

        var languageFileName = @$"{dataPath}Language.csv";
        var languageCsvFilePath = Path.Combine(baseDirectoryPath, languageFileName);
        await LanguageImporter.ImportAsync(applicationDbContext, adminUserPass, languageCsvFilePath);

        var playSessionFileName = @$"{dataPath}PlaySession.csv";
        var playSessionCsvFilePath = Path.Combine(baseDirectoryPath, playSessionFileName);
        await PlaySessionImporter.ImportAsync(applicationDbContext, adminUserPass, playSessionCsvFilePath);

        var romFileName = @$"{dataPath}Rom.csv";
        var romCsvFilePath = Path.Combine(baseDirectoryPath, romFileName);
        await RomImporter.ImportAsync(applicationDbContext, adminUserPass, romCsvFilePath);

        var romInputFileName = @$"{dataPath}RomInput.csv";
        var romInputCsvFilePath = Path.Combine(baseDirectoryPath, romInputFileName);
        await RomInputImporter.ImportAsync(applicationDbContext, adminUserPass, romInputCsvFilePath);

        var romStateFileName = @$"{dataPath}RomState.csv";
        var romStateCsvFilePath = Path.Combine(baseDirectoryPath, romStateFileName);
        await RomStateImporter.ImportAsync(applicationDbContext, adminUserPass, romStateCsvFilePath);

        var romTextFileName = @$"{dataPath}RomText.csv";
        var romTextCsvFilePath = Path.Combine(baseDirectoryPath, romTextFileName);
        await RomTextImporter.ImportAsync(applicationDbContext, adminUserPass, romTextCsvFilePath);

        var romTransitionFileName = @$"{dataPath}RomTransition.csv";
        var romTransitionCsvFilePath = Path.Combine(baseDirectoryPath, romTransitionFileName);
        await RomTransitionImporter.ImportAsync(applicationDbContext, adminUserPass, romTransitionCsvFilePath);

        var webSiteFileName = @$"{dataPath}WebSite.csv";
        var webSiteCsvFilePath = Path.Combine(baseDirectoryPath, webSiteFileName);
        await WebSiteImporter.ImportAsync(applicationDbContext, adminUserPass, webSiteCsvFilePath);

        var webSiteCategoryFileName = @$"{dataPath}WebSiteCategory.csv";
        var webSiteCategoryCsvFilePath = Path.Combine(baseDirectoryPath, webSiteCategoryFileName);
        await WebSiteCategoryImporter.ImportAsync(applicationDbContext, adminUserPass, webSiteCategoryCsvFilePath);

        var webSiteSubcategoryFileName = @$"{dataPath}WebSiteSubcategory.csv";
        var webSiteSubcategoryCsvFilePath = Path.Combine(baseDirectoryPath, webSiteSubcategoryFileName);
        await WebSiteSubcategoryImporter.ImportAsync(applicationDbContext, adminUserPass, webSiteSubcategoryCsvFilePath);

        // ImporterFirstCodePlaceholder

        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);
        await ApplicationUserRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserRoleCsvFilePath);
        await ApplicationUserImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserCsvFilePath);

        await CompanyImporter.ImportAsync(applicationDbContext, adminUserPass, companyCsvFilePath);
        await EmulatorImporter.ImportAsync(applicationDbContext, adminUserPass, emulatorCsvFilePath);
        await EmulatorCoreImporter.ImportAsync(applicationDbContext, adminUserPass, emulatorCoreCsvFilePath);
        await GameConsoleImporter.ImportAsync(applicationDbContext, adminUserPass, gameConsoleCsvFilePath);
        await LanguageImporter.ImportAsync(applicationDbContext, adminUserPass, languageCsvFilePath);
        await PlaySessionImporter.ImportAsync(applicationDbContext, adminUserPass, playSessionCsvFilePath);
        await RomImporter.ImportAsync(applicationDbContext, adminUserPass, romCsvFilePath);
        await RomInputImporter.ImportAsync(applicationDbContext, adminUserPass, romInputCsvFilePath);
        await RomStateImporter.ImportAsync(applicationDbContext, adminUserPass, romStateCsvFilePath);
        await RomTextImporter.ImportAsync(applicationDbContext, adminUserPass, romTextCsvFilePath);
        await RomTransitionImporter.ImportAsync(applicationDbContext, adminUserPass, romTransitionCsvFilePath);
        await WebSiteImporter.ImportAsync(applicationDbContext, adminUserPass, webSiteCsvFilePath);
        await WebSiteCategoryImporter.ImportAsync(applicationDbContext, adminUserPass, webSiteCategoryCsvFilePath);
        await WebSiteSubcategoryImporter.ImportAsync(applicationDbContext, adminUserPass, webSiteSubcategoryCsvFilePath);
        // ImporterSecondCodePlaceholder
    }
}
