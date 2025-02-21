using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class PlaySession
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public EmulatorCore? EmulatorCore { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsTest { get; set; }
    public Rom? Rom { get; set; }
    public DateTime StartDateTime { get; set; }
    // ActualPropertyPlaceholder
}
