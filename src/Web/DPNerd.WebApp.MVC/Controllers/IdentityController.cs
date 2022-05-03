using DPNerd.WebApp.MVC.Models;
using DPNerd.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DPNerd.WebApp.MVC.Controllers
{
    public class IdentityController : Controller
    {

        private readonly IAuthService _authService;

        public IdentityController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            var response = await _authService.Registro(usuarioRegistro);

            return View();
        }


        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }
    }
}
