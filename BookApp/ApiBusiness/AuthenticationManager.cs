using ApiBase.AuthenticationManagement;
using ApiBase.Models;
using Microsoft.Extensions.Options;

namespace ApiBusiness
{
    public class AuthenticationManager
    {
        private AuthenticationService authenticationService;
        public AuthenticationManager(IOptions<JwtSettingModel> jwtSettingModel)
        {
            this.authenticationService = new AuthenticationService(jwtSettingModel.Value);
        }
        public AuthResult LoginAsync(string username, string password)
        {
            //validate user
            
            AuthResult authResult = this.authenticationService.GenerateToken(new UserClaim { Name = username, UserId = username });
            return authResult;
        }
    }
}
