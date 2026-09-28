using Microsoft.AspNetCore.SignalR;

namespace WebAppSignalR.Hubs;

public class LoginHub : Hub
{
    // Permite que el cliente se una a un grupo con su identificador de verificación (p. ej. un GUID o Email)
    public async Task RegistrarEsperaVerificacion(string idUsuario)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, idUsuario);
    }
}