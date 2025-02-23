using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    public ApplicationRole? ApplicationRole { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
