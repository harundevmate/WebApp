namespace BookWebApi.Models.Auth
{
    /// <summary>
    /// Authentication Response Model
    /// </summary>
    public class AuthResponse
    {
        public string Token { get; set; }
        public int HttpStatusCode { get;set; }
        public string[] Message { get; set; }
    }
}