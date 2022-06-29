using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarCrud.Data;
using CarCrud.Models;

namespace WebApp2
{
    public class IndexModel : PageModel
    {
        private readonly CarCrud.Data.ShoppingCartContext _context;

        public IndexModel(CarCrud.Data.ShoppingCartContext context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Supplier != null)
            {
                Supplier = await _context.Supplier.ToListAsync();
            }
        }
    }
}
