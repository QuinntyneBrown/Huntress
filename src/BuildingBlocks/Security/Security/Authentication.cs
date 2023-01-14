namespace Security;

public class Authentication
{
    public string TokenPath { get; set; } = null!;
    public int ExpirationMinutes { get; set; }
    public string JwtKey { get; set; } = null!;
    public string JwtIssuer { get; set; } = null!; 
    public string JwtAudience { get; set; } = null!;
    public string AuthType { get; set; } = null!;
}
