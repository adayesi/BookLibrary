using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MemberDto
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PhotoUrl { get; set; }
            public DateTime Created { get; set; }
            public DateTime LastActive { get; set; }
            public string Gender { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public ICollection<PhotoDto> Photos { get; set; }
        
    }
}
