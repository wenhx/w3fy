using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using W3fy.Data;
using W3fy.Models;

namespace W3fy.Portal.Pages;

public class IndexModel : PageModel
{
    private readonly W3fyDbContext m_DbContext;

    public IndexModel(W3fyDbContext context)
    { 
        m_DbContext = context;
    }

    public IList<Topic> Topics { get; set; } = new List<Topic>();

    public async Task OnGetAsync()
    {
        Topics = await m_DbContext.Topics.OrderByDescending(t => t.Created).Take(Constants.Pagination.PageSize).AsNoTracking().ToListAsync();
    }
}