using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Data.Repositories;

namespace Termin.Hubs
{
    public class TimerHub : Hub
    {
        private TestRepository testRepository;

        public TimerHub(TestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        public async Task GetTimer()
        {
            string time = "May 21, 2021 19:37:25";
            await Clients.All.SendAsync("RevieveTimer", time);
        }
    }
}
