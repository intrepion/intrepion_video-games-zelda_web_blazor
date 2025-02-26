using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = [];
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public ICollection<ApplicationRole> UpdatedApplicationRoles { get; set; } = [];
    public ICollection<ApplicationRoleClaim> UpdatedApplicationRoleClaims { get; set; } = [];
    public ICollection<ApplicationUser> UpdatedApplicationUsers { get; set; } = [];
    public ICollection<ApplicationUserClaim> UpdatedApplicationUserClaims { get; set; } = [];
    public ICollection<ApplicationUserLogin> UpdatedApplicationUserLogins { get; set; } = [];
    public ICollection<ApplicationUserRole> UpdatedApplicationUserRoles { get; set; } = [];
    public ICollection<ApplicationUserToken> UpdatedApplicationUserTokens { get; set; } = [];

    public ICollection<Company> UpdatedCompanies { get; set; } = [];
    public ICollection<Emulator> UpdatedEmulators { get; set; } = [];
    public ICollection<EmulatorCore> UpdatedEmulatorCores { get; set; } = [];
    public ICollection<GameConsole> UpdatedGameConsoles { get; set; } = [];
    public ICollection<Language> UpdatedLanguages { get; set; } = [];
    public ICollection<PlaySession> UpdatedPlaySessions { get; set; } = [];
    public ICollection<Rom> UpdatedRoms { get; set; } = [];
    public ICollection<RomInput> UpdatedRomInputs { get; set; } = [];
    public ICollection<RomState> UpdatedRomStates { get; set; } = [];
    public ICollection<RomText> UpdatedRomTexts { get; set; } = [];
    public ICollection<RomTransition> UpdatedRomTransitions { get; set; } = [];
    public ICollection<WebSite> UpdatedWebSites { get; set; } = [];
    public ICollection<WebSiteCategory> UpdatedWebSiteCategories { get; set; } = [];
    public ICollection<WebSiteSubcategory> UpdatedWebSiteSubcategories { get; set; } = [];
    // ActualPropertyPlaceholder
}
