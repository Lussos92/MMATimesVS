using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseLayer.Models
{
    public partial class NewsStory
    {
        public int NewsStoryId { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string MainBody { get; set; }
        public int? AuthorName { get; set; }
    }
}
