namespace BookWebApi.Models.Auth
{
    /// <summary>
    /// Login Request Model
    /// </summary>
    public class LoginModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
