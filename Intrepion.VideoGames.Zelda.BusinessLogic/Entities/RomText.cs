using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class RomText
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public bool IsTest { get; set; }
    public RomState? RomState { get; set; }
    public string Text { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
