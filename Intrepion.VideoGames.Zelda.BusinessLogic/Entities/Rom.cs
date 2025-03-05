using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class Rom
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    [Required]
    public string FileName { get; set; } = string.Empty;
    [Required]
    public string NormalizedFileName { get; set; } = string.Empty;
    public GameConsole? GameConsole { get; set; }
    public bool IsTest { get; set; }
    public ICollection<PlaySession> PlaySessions { get; set; } = [];
    [Required]
    public string Sha256Sum { get; set; } = string.Empty;
    [Required]
    public string AlphanumericSha256Sum { get; set; } = string.Empty;
    public WebSite? WebSite { get; set; }
    public WebSiteSubcategory? WebSiteSubcategory { get; set; }
    // ActualPropertyPlaceholder
}
