using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxyHubRazor.Models
{
    public class mqttData
    {
        public int ID { get; set; }
        public int feuchtigkeit { get; set; }
        public int temperatur { get; set; }
        public int tvoc { get; set; }
        public int eco2 { get; set; }
        public int airQuality { get; set; }
        public int airQualityPrecision { get; set; }
        public int rawh2 { get; set; }
        public int rawEthanol { get; set; }
    }
}
