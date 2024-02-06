using Microsoft.AspNetCore.SignalR;

namespace scoreGr03.Hubs;

public class JoueurHub : Hub
{
    public async Task SendMessage()
    {
        await Clients.All.SendAsync("JoueurChange");
    }
}
