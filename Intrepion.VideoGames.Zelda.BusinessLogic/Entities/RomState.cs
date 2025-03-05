using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class RomState
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public bool IsTest { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string NormalizedName { get; set; } = string.Empty;
    public ICollection<RomText> RomTexts { get; set; } = [];
    public ICollection<RomTransition> PreviousRomTransitions { get; set; } = [];
    public ICollection<RomTransition> RomTransitions { get; set; } = [];
    public int T { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    // ActualPropertyPlaceholder
}
