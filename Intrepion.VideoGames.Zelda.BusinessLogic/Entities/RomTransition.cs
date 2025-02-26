using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class RomTransition
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public bool IsTest { get; set; }
    public RomState? PreviousRomState { get; set; }
    public RomInput? RomInput { get; set; }
    public RomState? RomState { get; set; }
    // ActualPropertyPlaceholder
}
