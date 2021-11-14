using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace W3fy.Data;

public static class DevelopmentDataSeeder
{
    const int s_SecondsNumberInAWholeMonth = 3600 * 24 * 30;
    static readonly Random s_Random = new ();
    static readonly int s_MaxRandomCount = 100;

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new W3fyDbContext(serviceProvider.GetRequiredService<DbContextOptions<W3fyDbContext>>());
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        //if (context.Topics.Any())
        //    return;

        var numberOfTopics = 102;
        for (int i = 0; i < numberOfTopics; i++)
        {
            var topic = new Models.Topic(Guid.NewGuid().ToString(), "Subject " + i, "Content " + i, "author " + i);
            topic.Created = DateTime.Now.AddSeconds(GetRandomSeconds());
            topic.RepliedCount = s_Random.Next(s_MaxRandomCount);
            context.Topics.Add(topic);
        }
        context.SaveChanges();
    }

    private static double GetRandomSeconds()
    {
        return (double)s_Random.Next(-s_SecondsNumberInAWholeMonth, s_SecondsNumberInAWholeMonth);
    }
}
