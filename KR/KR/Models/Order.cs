namespace KR.Models
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
