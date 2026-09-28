using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebAppSignalR.Hubs;

namespace WebAppSignalR.Controllers;

public class AccountController : Controller
{
    private readonly IHubContext<LoginHub> _hubContext;

    public AccountController(IHubContext<LoginHub> hubContext)
    {
        _hubContext = hubContext;
    }

    // GET: /Account/Login
    public IActionResult Login()
    {
        // Generamos un ID de sesión/verificación único para la prueba
        ViewBag.IdUsuario = "usuario123"; 
        return View();
    }

    // GET: /Account/VerificarEmail?idUsuario=usuario123
    public async Task<IActionResult> VerificarEmail(string idUsuario)
    {
        // Simula la verificación del email en base de datos...

        // Notifica ÚNICAMENTE al grupo asociado a este idUsuario
        await _hubContext.Clients.Group(idUsuario).SendAsync("UsuarioVerificado", "/Home/Index");

        return Ok($"El correo de '{idUsuario}' ha sido verificado con éxito. Revisa la pestaña de Login.");
    }
}