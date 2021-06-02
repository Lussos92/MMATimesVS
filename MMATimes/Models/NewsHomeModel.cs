using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMATimes.Models
{
    public class NewsHomeModel
    {
        public List<NewsStoryModel> NewsStories = new List<NewsStoryModel>();
    }

    public class NewsStoryModel
    {
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string MainBody { get; set; }
    }
}
