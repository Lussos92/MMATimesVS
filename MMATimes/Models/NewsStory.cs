using System;
using System.Collections.Generic;

#nullable disable

namespace MMATimes.Models
{
    public partial class NewsStory
    {
        public int NewsStoryId { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string MainBody { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
