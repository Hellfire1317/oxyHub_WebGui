using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using oxyHubRazor.Models;

namespace oxyHubRazor.Data
{
    public class oxyHubRazorContext : DbContext
    {
        public oxyHubRazorContext (DbContextOptions<oxyHubRazorContext> options)
            : base(options)
        {
        }

        public DbSet<oxyHubRazor.Models.mqttData> mqttData { get; set; }
    }
}
