namespace BookingService.API.Auth
{
    public class JWTTokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
