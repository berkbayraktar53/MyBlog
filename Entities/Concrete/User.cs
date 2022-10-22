using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}