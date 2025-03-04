using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class WebSite
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public bool IsTest { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string NormalizedName { get; set; } = string.Empty;
    [Required]
    public string Url { get; set; } = string.Empty;
    [Required]
    public ICollection<Rom> Roms { get; set; } = [];
    public ICollection<WebSiteCategory> WebSiteCategories { get; set; } = [];
    public ICollection<WebSiteSubcategory> WebSiteSubcategories { get; set; } = [];
    // ActualPropertyPlaceholder
}
