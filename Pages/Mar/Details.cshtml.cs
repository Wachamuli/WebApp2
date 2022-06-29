using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarCrud.Data;
using CarCrud.Models;

namespace WebApp2.Pages.Mar
{
    public class DetailsModel : PageModel
    {
        private readonly CarCrud.Data.ShoppingCartContext _context;

        public DetailsModel(CarCrud.Data.ShoppingCartContext context)
        {
            _context = context;
        }

      public Mark Mark { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mark == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark.FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }
            else 
            {
                Mark = mark;
            }
            return Page();
        }
    }
}
