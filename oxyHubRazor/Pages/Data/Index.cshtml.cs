using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oxyHubRazor.Data;
using oxyHubRazor.Models;

namespace oxyHubRazor.Pages.Data
{
    public class IndexModel : PageModel
    {
        private readonly oxyHubRazor.Data.oxyHubRazorContext _context;

        public IndexModel(oxyHubRazor.Data.oxyHubRazorContext context)
        {
            _context = context;
        }

        public IList<mqttData> mqttData { get;set; }

        public async Task OnGetAsync()
        {
            mqttData = await _context.mqttData.ToListAsync();
        }
    }
}
