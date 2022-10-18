namespace HRMS.Application.AuthenticateRefreshToken
{
    public class AuthenticateRefreshTokenResponse
    {
        public bool IsAuthenticate { get; set; }
        public string? AccessToken { get; set; }
        public string? ResfreshToken { get; set; }
    }
}
