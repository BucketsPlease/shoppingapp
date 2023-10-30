using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Models
{
    public class ProductItem
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Image { get; set; }

        public virtual ICollection<AppUserProductItem> UserProductItems { get; set; }
    }
}
