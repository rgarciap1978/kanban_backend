using KanbanBoard.Service.Interface;
using KanbanBoard.Shared.Request;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginRequest request)
        {
            var response = await _service.LoginAsync(request);
            return response.Success ? Ok(response) : StatusCode((int)StatusCodes.Status401Unauthorized, response);
        }
    }
}
