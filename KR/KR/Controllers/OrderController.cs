using KR.Models;
using Microsoft.AspNetCore.Mvc;

namespace KR.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        [HttpGet("checkout")]
        public IActionResult Checkout()
        {
            var order = new Order();
            order.Items = ShoppingCart.Items.ToList(); 

            return View(order);
        }

        [HttpPost("placeOrder")]
        public IActionResult PlaceOrder(Order order)
        {
            ShoppingCart.Items.Clear();

            TempData["OrderPlaced"] = true; 

            return RedirectToAction("OrderConfirmation");
        }

        [HttpGet("confirmation")]
        public IActionResult OrderConfirmation()
        {          
            if (TempData["OrderPlaced"] as bool? == true)
            {
                ViewBag.ConfirmationMessage = "Order placed successfully!";
            }
            else
            {
                ViewBag.ConfirmationMessage = "There was an error processing your order.";
            }

            return View();
        }
    }
}
