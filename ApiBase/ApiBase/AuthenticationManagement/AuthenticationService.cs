using ApiBase.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiBase.AuthenticationManagement
{
    public partial class AuthenticationService
    {
        private JwtSettingModel _jwtSettingModel { get; set; }

        public AuthenticationService(JwtSettingModel jwtSettingModel)
        {
            this._jwtSettingModel = jwtSettingModel;
        }
        public AuthResult GenerateToken(UserClaim user)
        {
            ClaimModel claim = CreateClaim(user);
            JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
            var token = CreateToken(claim, tokenhandler);
            return new AuthResult()
            {
                Success = true,
                Token = tokenhandler.WriteToken(token),
                Error = null
            };
        }

        private ClaimModel CreateClaim(UserClaim user)
        {
            ClaimModel claim = new ClaimModel()
            {
                Sid = user.UserId,
                NameIdentifier = user.UserId,
                Jti = Guid.NewGuid().ToString(),
                Name = user.Name
            };
            return claim;
        }

        private SecurityToken CreateToken(ClaimModel claim,JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettingModel.Secret);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sid,claim.Sid??""),
                new Claim(ClaimTypes.NameIdentifier,claim.NameIdentifier??""),
                new Claim(JwtRegisteredClaimNames.Jti,claim.Jti??""),
                new Claim(ClaimTypes.Name,claim.Name??"")
            });
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.Add(_jwtSettingModel.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            };
            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return token;
        }
    }
}
