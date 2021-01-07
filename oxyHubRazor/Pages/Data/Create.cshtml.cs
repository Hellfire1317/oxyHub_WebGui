using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using oxyHubRazor.Data;
using oxyHubRazor.Models;

namespace oxyHubRazor.Pages.Data
{
    public class CreateModel : PageModel
    {
        private readonly oxyHubRazor.Data.oxyHubRazorContext _context;

        public CreateModel(oxyHubRazor.Data.oxyHubRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public mqttData mqttData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.mqttData.Add(mqttData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
