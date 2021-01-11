using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oxyHubRazor.Data;
using oxyHubRazor.Models;
using shellCommands;

namespace oxyHubRazor.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly oxyHubRazor.Data.oxyHubRazorContext _context;

        public IndexModel(oxyHubRazor.Data.oxyHubRazorContext context)
        {
            _context = context;
        }

        public StatusModel SystemState { get; set; }
        public IList<mqttData> mqttData { get; set; }

        public async Task OnGetAsync()
        {
            mqttData = await _context.mqttData.ToListAsync();
            SystemState = new StatusModel()
            {
                HostapdRunning = false,
                MqttdRunning = false,
                Sensor1Online = false,
                Sensor2Online = true,
                Sensor3Online = true,
                Sensor4Online = false,
            }; 
        }

        public void OnPostRestartHostapd()
        {
            controller oxyHub = new controller();
            oxyHub.restartHostapd();
        }

        
    }
}
