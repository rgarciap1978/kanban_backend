using KanbanBoard.DataAccess;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using KanbanBoard.Service.Interface;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace KanbanBoard.Service
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<KanbanBoardLoginIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<AppConfig> _options;

        public LoginService(
            UserManager<KanbanBoardLoginIdentity> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<AppConfig> options)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _options = options;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = new LoginResponse();

            try
            {
                var identity = await _userManager.FindByEmailAsync(request.Username);
                if (identity == null)
                {
                    throw new SecurityException("User not found.");
                }

                if (await _userManager.IsLockedOutAsync(identity))
                {
                    throw new SecurityException("Too many attempts.");
                }

                var result = await _userManager.CheckPasswordAsync(identity, request.Password);
                if (!result)
                {
                    await _userManager.AccessFailedAsync(identity);
                    throw new SecurityException("Password wrong");
                }

                var roles = await _userManager.GetRolesAsync(identity);
                var expiredDate = DateTime.Now.AddHours(1);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, identity.Email!),
                    new Claim(ClaimTypes.Expiration, expiredDate.ToString("yyyy-MM-dd HH:mm:ss"))
                };

                claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

                response.Roles = new List<string>();
                response.Roles.AddRange(roles);

                var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Jwt.SecretKey));
                var credencials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
                var header = new JwtHeader(credencials);
                var payload = new JwtPayload(
                    _options.Value.Jwt.Issuer,
                    _options.Value.Jwt.Audience,
                    claims,
                    DateTime.Now,
                    expiredDate
                    );

                var token = new JwtSecurityToken(header, payload);

                response.Token = new JwtSecurityTokenHandler().WriteToken(token);
                response.Fullname = $"{identity.FirstName} {identity.LastName}";

                string initials = identity.FirstName.Substring(0, 1);
                if (!string.IsNullOrEmpty(identity.LastName)) initials += identity.LastName.Substring(0, 1);
                response.Initials = initials.ToUpper();
                response.Success = true;
            }
            catch (SecurityException ex)
            {
                response.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
