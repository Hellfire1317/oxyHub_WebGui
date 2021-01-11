using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxyHubRazor.Models
{
    public class StatusModel
    {
        public bool MqttdRunning { get; set; }
        public bool HostapdRunning { get; set; }
        public bool Sensor1Online { get; set; }
        public bool Sensor2Online { get; set; }
        public bool Sensor3Online { get; set; }
        public bool Sensor4Online { get; set; }
    }
}
