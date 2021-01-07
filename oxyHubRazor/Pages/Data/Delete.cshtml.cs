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
    public class DeleteModel : PageModel
    {
        private readonly oxyHubRazor.Data.oxyHubRazorContext _context;

        public DeleteModel(oxyHubRazor.Data.oxyHubRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public mqttData mqttData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            mqttData = await _context.mqttData.FirstOrDefaultAsync(m => m.ID == id);

            if (mqttData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            mqttData = await _context.mqttData.FindAsync(id);

            if (mqttData != null)
            {
                _context.mqttData.Remove(mqttData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
