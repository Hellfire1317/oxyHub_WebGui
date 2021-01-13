using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using oxyHubRazor.Models;
using shellCommands;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace oxyHubRazor.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly oxyHubRazor.Data.oxyHubRazorContext _context;

        public IndexModel(oxyHubRazor.Data.oxyHubRazorContext context)
        {
            _context = context;
        }

        controller oxyHub = new controller();

        public StatusModel SystemState { get; set; }
        public IList<mqttData> mqttData { get; set; }

        public async Task OnGetAsync()
        {
            SystemState = new StatusModel();
            mqttData = await _context.mqttData.ToListAsync();
            SystemState.Sensor1Online = oxyHub.PingSensor(IPAddress.Parse("10.10.10.10"));
            SystemState.Sensor2Online = oxyHub.PingSensor(IPAddress.Parse("10.10.10.11"));
            SystemState.Sensor3Online = oxyHub.PingSensor(IPAddress.Parse("10.10.10.12"));
            SystemState.Sensor4Online = oxyHub.PingSensor(IPAddress.Parse("10.10.10.13"));
            //SystemState.HostapdRunning = oxyHub.CheckService("hostapd");
            //SystemState.MqttdRunning = oxyHub.CheckService("mqtt");
        }

        public void OnPostRestartHostapd()
        {
           
            oxyHub.restartHostapd();
        }

        
    }
}
