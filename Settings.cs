using Microsoft.Extensions.Configuration;

public class Settings
{
    public string? ClientId { get; set; }
    public string? TenantId { get; set; }
    public string[]? Scopes { get; set; }
    public string? NightscoutUrl { get; set; }
    public string? ApiKey { get; set; }

    public static Settings LoadSettings()
    {
        // Load settings
        IConfiguration config = new ConfigurationBuilder()
            // appsettings.json is required
            .AddJsonFile("appsettings.json", optional: false)
            // appsettings.Development.json" is optional, values override appsettings.json
            .AddJsonFile($"appsettings.Development.json", optional: true)
            .Build();

        return config.GetRequiredSection("Settings").Get<Settings>() ??
            throw new Exception("Could not load app settings.");
    }
}