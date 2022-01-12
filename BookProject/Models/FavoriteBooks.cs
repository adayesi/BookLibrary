using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FavoriteBooks : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }

        //public bool IsFavorite { get; set; }
    }
}
