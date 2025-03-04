using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class WebSiteSubcategory
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public bool IsTest { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string NormalizedName { get; set; } = string.Empty;
    public ICollection<Rom> Roms { get; set; } = [];
    public WebSite? WebSite { get; set; }
    public WebSiteCategory? WebSiteCategory { get; set; }
    // ActualPropertyPlaceholder
}
