using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BookDto : BaseEntity
    {
        
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }
        public string CoverUrl { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}
