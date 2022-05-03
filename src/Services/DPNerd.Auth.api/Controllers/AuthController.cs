using DPNerd.Auth.api.Models;
using DPNerd.WebAPI.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DPNerd.Auth.api.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager, 
            IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                Console.WriteLine("Registrar Funcionario");
            }

            return NoContent();
        }
    }
}
