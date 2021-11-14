using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace W3fy.Models;

public class Topic
{
    public Topic(string id, string title, string content, string author)
    { 
        Id = id;
        Title = title;
        Content = content;
        Author = author;
        RepliedCount = 0;
        Created = DateTime.Now;
    }

    [StringLength(Constants.Data.GuidLength)]
    public string Id { get; set; }

    [StringLength(Constants.Data.NameLength)]
    public string Title { get; set; }

    public string Content { get; set; }

    public string Author { get; set; }

    public int RepliedCount { get; set; }

    public DateTime Created { get; set; }
}