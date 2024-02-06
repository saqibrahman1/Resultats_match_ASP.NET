using Microsoft.AspNetCore.SignalR;

namespace scoreGr03.Hubs;

public class EquipeHub : Hub
{
    public async Task SendMessage()
    {
        await Clients.All.SendAsync("EquipeChange");
    }
}


    
