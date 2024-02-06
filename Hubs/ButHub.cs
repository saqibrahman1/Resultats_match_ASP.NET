using Microsoft.AspNetCore.SignalR;
namespace scoreGr03.Hubs;

public class ButHub: Hub
{
    public async Task SendMessage()
    {
        await Clients.All.SendAsync("ButChange");
    }
}

