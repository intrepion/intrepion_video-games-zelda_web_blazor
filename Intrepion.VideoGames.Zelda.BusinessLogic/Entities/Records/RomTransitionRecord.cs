namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;

public class RomTransitionRecord
{
    public bool IsTest { get; set; }
    public string PreviousRomState_NormalizedName { get; set; } = string.Empty;
    public string RomInput_NormalizedName { get; set; } = string.Empty;
    public string RomState_NormalizedName { get; set; } = string.Empty;
    // RecordPropertyCodePlaceholder
}
