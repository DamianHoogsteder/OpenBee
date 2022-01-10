using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeService.HubConfig
{
    public class TradeHub : Hub
    {

        public async Task askServer(string someTextFromClient)
        {
            string tempString;

            if (someTextFromClient == "zephtos")
            {
                tempString = "Trade offer from zephtos";
            }
            else
            {
                tempString = "no trade offer";
            }

            await Clients.All.SendAsync("askServerResponse", tempString);
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
