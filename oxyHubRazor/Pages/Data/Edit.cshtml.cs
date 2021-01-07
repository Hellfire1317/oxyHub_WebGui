using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using oxyHubRazor.Data;
using oxyHubRazor.Models;

namespace oxyHubRazor.Pages.Data
{
    public class EditModel : PageModel
    {
        private readonly oxyHubRazor.Data.oxyHubRazorContext _context;

        public EditModel(oxyHubRazor.Data.oxyHubRazorContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(mqttData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mqttDataExists(mqttData.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool mqttDataExists(int id)
        {
            return _context.mqttData.Any(e => e.ID == id);
        }
    }
}
