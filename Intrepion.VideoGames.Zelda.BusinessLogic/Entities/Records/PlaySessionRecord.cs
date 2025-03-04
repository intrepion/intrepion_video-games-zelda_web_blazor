namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;

public class PlaySessionRecord
{
    public string EmulatorCore_NormalizedName { get; set; } = string.Empty;
    public DateTime EndDateTime { get; set; }
    public bool IsTest { get; set; }
    public string Rom_AlphanumericSha256Sum { get; set; } = string.Empty;
    public DateTime StartDateTime { get; set; }
    // RecordPropertyCodePlaceholder
}
