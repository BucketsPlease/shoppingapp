using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<AppUserProductItem> UserProductItems { get; set; }
    }
}
