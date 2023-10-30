namespace ShoppingApp.Data.Models
{
    public class AppUserProductItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int ProductItemId { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}
