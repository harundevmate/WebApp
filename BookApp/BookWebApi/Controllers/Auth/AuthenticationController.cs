using ApiBase.Helpers.Contanta;
using ApiBase.Models;
using ApiBusiness;
using BookWebApi.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AuthenticationManager = ApiBusiness.AuthenticationManager;

namespace BookApp.Controllers.Auth
{
    [Route("api/auth/[action]")]
    [ApiController]
    public partial class AuthenticationController : ControllerBase
    {
        private AuthenticationManager authenticationManager { get; set; }
        public AuthenticationController(AuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }
        [HttpPost]
        public ActionResult Login([FromBody] LoginModel data)
        {
            if (data != null)
            {
                AuthResult authResult = this.authenticationManager.LoginAsync(data.UserId, data.Password);
                if (authResult != null)
                    return Ok(new AuthResponse()
                    {
                        HttpStatusCode = (int)HttpStatusCode.OK,
                        Token = authResult.Token
                    });
                else
                    return Ok(new AuthResponse()
                    {
                        HttpStatusCode = (int)HttpStatusCode.Unauthorized,
                        Message = new string[] { ConstHelper.InvalidParam }
                    });
            }
            return Ok(new AuthResponse()
            {
                HttpStatusCode = (int)HttpStatusCode.Unauthorized,
                Message = new string[] { ConstHelper.InvalidParam }
            });
        }
    }
}