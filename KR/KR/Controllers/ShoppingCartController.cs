using KR.Models;
using Microsoft.AspNetCore.Mvc;

namespace KR.Controllers
{
    [ApiController]
    [Route("api/shoppingCart")]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShoppingCart()
        {
            var order = new Order();
            order.Items = ShoppingCart.Items.ToList(); // Копіюємо елементи з кошика у замовлення

            return View("ShoppingCart", order);
        }
    }
}
