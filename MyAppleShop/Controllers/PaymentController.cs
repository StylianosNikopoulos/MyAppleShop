using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAppleShop.Data;
using MyAppleShop.Models;
using Stripe.Checkout;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAppleShop.Controllers
{

    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PaymentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var viewMode = new ProductViewModel
            {
                Products = await _context.products.ToListAsync(),
                Watches = await _context.watches.ToListAsync()
            };
            return View(viewMode);
        }
        [AutoValidateAntiforgeryToken]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCheckout([Bind("Id,Name,ImageUrl,PriceId")] Product product)
        {
            var domain = "https://localhost:7119";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        //Price = product.PriceId,
                        Price = "price_1Pls2DBlT4Q7uMDZij67DKyD", 
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "/Payment/Cancel",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "Anonymous";
            var userEmail = User.Identity.IsAuthenticated ? (await _userManager.FindByIdAsync(userId))?.Email : "Anonymous";

            var productPurchase = new ProductPurchase
            {
                ProductId = product.Id,
                UserId = userId,
                UserEmail = userEmail, 
                PurchaseDate = DateTime.UtcNow
            };
            _context.ProductPurchases.Add(productPurchase);
            await _context.SaveChangesAsync();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
        [AutoValidateAntiforgeryToken]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWatchCheckout([Bind("Id,Name,ImageUrl,PriceId")] Watch watch)
        {
            var domain = "https://localhost:7119";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        //Price = watch.PriceId,
                        Price ="price_1Pm9XdBlT4Q7uMDZ5Acg63Ve",
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "/Cancel/Success",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            // Capture the UserId from the authentication context
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "Anonymous";
            var userEmail = User.Identity.IsAuthenticated ? (await _userManager.FindByIdAsync(userId))?.Email : "Anonymous";


            var watchPurchase = new WatchPurchase
            {
                WatchId = watch.Id,
                UserId = userId,
                UserEmail = userEmail,
                PurchaseDate = DateTime.UtcNow
            };
            _context.WatchPurchases.Add(watchPurchase);
            await _context.SaveChangesAsync();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }
    }
}

