using CraftCutsTestApiProject.Contracts;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Repositories
{
    public class InformHub : Hub<IHubClient>
    {
        //public async Task InformClient1(string message)
        //{
        //    await Clients.All.InformClient(message);
        //}
       
    }
}
