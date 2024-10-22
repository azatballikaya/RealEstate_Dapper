using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = "Select * From AppUser Where Username=@username and Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", createLoginDto.Username);
            parameters.Add("@password", createLoginDto.Password);
            using (var connection=_context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultAppUserDto>(query,parameters);
                if (values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel()
                    {
                        Id=values.UserID,
                        Username=values.Username,
                        Role="Admin"
                    };
                    var token=JwtTokenGenerator.GenerateToken(model);
                   return Ok(token);
                }
                return Unauthorized();
            }
        }
    }
}
