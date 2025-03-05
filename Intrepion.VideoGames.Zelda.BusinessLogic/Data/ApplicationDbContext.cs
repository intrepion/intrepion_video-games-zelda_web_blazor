using Intrepion.VideoGames.Zelda.BusinessLogic.Entities;
using Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Emulator> Emulators { get; set; }
    public DbSet<EmulatorCore> EmulatorCores { get; set; }
    public DbSet<GameConsole> GameConsoles { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<PlaySession> PlaySessions { get; set; }
    public DbSet<Rom> Roms { get; set; }
    public DbSet<RomInput> RomInputs { get; set; }
    public DbSet<RomState> RomStates { get; set; }
    public DbSet<RomText> RomTexts { get; set; }
    public DbSet<RomTransition> RomTransitions { get; set; }
    public DbSet<WebSite> WebSites { get; set; }
    public DbSet<WebSiteCategory> WebSiteCategories { get; set; }
    public DbSet<WebSiteSubcategory> WebSiteSubcategories { get; set; }
    // DbSetCodePlaceholder

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new ApplicationRoleClaimEtc().Configure(builder.Entity<ApplicationRoleClaim>());
        new ApplicationRoleEtc().Configure(builder.Entity<ApplicationRole>());
        new ApplicationUserClaimEtc().Configure(builder.Entity<ApplicationUserClaim>());
        new ApplicationUserEtc().Configure(builder.Entity<ApplicationUser>());
        new ApplicationUserLoginEtc().Configure(builder.Entity<ApplicationUserLogin>());
        new ApplicationUserRoleEtc().Configure(builder.Entity<ApplicationUserRole>());
        new ApplicationUserTokenEtc().Configure(builder.Entity<ApplicationUserToken>());

        new CompanyEtc().Configure(builder.Entity<Company>());
        new EmulatorEtc().Configure(builder.Entity<Emulator>());
        new EmulatorCoreEtc().Configure(builder.Entity<EmulatorCore>());
        new GameConsoleEtc().Configure(builder.Entity<GameConsole>());
        new LanguageEtc().Configure(builder.Entity<Language>());
        new PlaySessionEtc().Configure(builder.Entity<PlaySession>());
        new RomEtc().Configure(builder.Entity<Rom>());
        new RomInputEtc().Configure(builder.Entity<RomInput>());
        new RomStateEtc().Configure(builder.Entity<RomState>());
        new RomTextEtc().Configure(builder.Entity<RomText>());
        new RomTransitionEtc().Configure(builder.Entity<RomTransition>());
        new WebSiteEtc().Configure(builder.Entity<WebSite>());
        new WebSiteCategoryEtc().Configure(builder.Entity<WebSiteCategory>());
        new WebSiteSubcategoryEtc().Configure(builder.Entity<WebSiteSubcategory>());
        // EntityTypeCfgCodePlaceholder
    }
}
