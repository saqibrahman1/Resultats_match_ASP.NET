using Microsoft.AspNetCore.SignalR;

namespace scoreGr03.Hubs;

public class MatchHub : Hub
{
    public async Task SendMessage()
    {
        await Clients.All.SendAsync("MatchChange");
    }
}
