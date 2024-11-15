using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFest2024BookStore.Models;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }

    // Navigation property
    public ICollection<Author> Authors { get; set; } = new List<Author>();  
}
