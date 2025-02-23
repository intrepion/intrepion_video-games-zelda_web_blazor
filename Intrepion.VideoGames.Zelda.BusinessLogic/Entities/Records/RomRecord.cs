namespace Intrepion.VideoGames.Zelda.BusinessLogic.Entities.Records;

public class RomRecord
{
    public string FileName { get; set; } = string.Empty;
    public string GameConsole_NormalizedName { get; set; } = string.Empty;
    public bool IsTest { get; set; }
    public string Sha256Sum { get; set; } = string.Empty;
    public string WebSiteSubcategory_NormalizedName { get; set; } = string.Empty;
    // RecordPropertyCodePlaceholder
}
