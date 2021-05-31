using System;
using System.Collections.Generic;
using System.Text;

namespace NewsService.Models
{
    [Serializable]
    public class NewsPost
    {
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string MainBody { get; set; }
    }
}
