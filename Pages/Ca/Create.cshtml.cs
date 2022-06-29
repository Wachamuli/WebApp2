using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarCrud.Data;
using CarCrud.Models;

namespace WebApp2.Pages.Ca
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
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
        ViewData["MarkId"] = new SelectList(_context.Mark, "Id", "Name");
        ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Car == null || Car == null)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
