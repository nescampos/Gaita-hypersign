namespace Gaita.Hypersign.Services.DTO
{
    public class OAuthDTO
    {
        public string? access_token { get; set; }
        public int? expiresIn { get; set; }
        public string? tokenType { get; set; }
    }
}
