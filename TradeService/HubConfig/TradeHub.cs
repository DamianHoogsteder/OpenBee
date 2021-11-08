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
                tempString = "trade offer from zephtos";
            }
            else
            {
                tempString = "no trade offer";
            }

            await Clients.Clients(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);
        }
    }
}
