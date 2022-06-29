using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarCrud.Data;
using CarCrud.Models;

namespace WebApp2.Pages.Mar
{
    public class CreateModel : PageModel
    {
        private readonly CarCrud.Data.ShoppingCartContext _context;

        public CreateModel(CarCrud.Data.ShoppingCartContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mark Mark { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Mark == null || Mark == null)
            {
                return Page();
            }

            _context.Mark.Add(Mark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
