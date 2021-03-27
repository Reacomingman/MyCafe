using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MyCafe_v1._5.Utils
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage to update clinets
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}