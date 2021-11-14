using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W3fy.Data;
using W3fy.Models;

namespace W3fy.Portal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly W3fyDbContext _context;

        public IndexModel(W3fyDbContext context)
        { 
            _context = context;
        }

        public IList<Topic> Topics { get; set; } = new List<Topic>();

        public async Task OnGetAsync()
        {
            Topics = await _context.Topics.OrderByDescending(t => t.Created).Take(Constants.Pagination.PageSize).AsNoTracking().ToListAsync();
        }
    }
}
