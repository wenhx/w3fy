using Microsoft.EntityFrameworkCore;

namespace W3fy.Data;

public class W3fyDbContext : DbContext
{
    public W3fyDbContext(DbContextOptions<W3fyDbContext> options) : base(options) { }

    public DbSet<Models.Topic> Topics => Set<Models.Topic>();
}