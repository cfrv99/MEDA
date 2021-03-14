using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MainUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
