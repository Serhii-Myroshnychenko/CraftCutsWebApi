using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<InformHub, IHubClient> _informHub;

        public MessageController(IHubContext<InformHub, IHubClient> informHub)
        {
            _informHub = informHub;
        }
        [HttpGet]
        public string Get()
        {
            string str = "Notification";
            string isSend = "";
            try
            {
                _informHub.Clients.All.InformClient(str);
                isSend = "Success";

            }
            catch (Exception ex)
            {
                isSend = ex.ToString();
            }
            return isSend; 
        }

        
    }
}
