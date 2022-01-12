using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string CoverUrl { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

        public List<FavoriteBooks> FavoriteBooks { get; set; }

        public Book()
        {
            FavoriteBooks = new List<FavoriteBooks>();
        }
    }
}
