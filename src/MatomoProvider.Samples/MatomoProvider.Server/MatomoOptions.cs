namespace MatomoProvider.Server;

public class MatomoOptions
{
    public string ApiUrl { get; set; }
    public int SiteId { get; set; }

    public static string Path => "Matomo";
}
