using System;
using System.Collections.Generic;

#nullable disable

namespace MMATimes.Models
{
    public partial class Author
    {
        public Author()
        {
            NewsStories = new HashSet<NewsStory>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public virtual ICollection<NewsStory> NewsStories { get; set; }
    }
}
