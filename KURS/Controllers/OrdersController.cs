using KURS.DAL;
using KURS.Models;
using KURS.Models.DBentities;
using Microsoft.AspNetCore.Mvc;

namespace KURS.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersDbContext _context;

        public OrdersController(OrdersDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            List<OrdersViewModel> ordersList = new List<OrdersViewModel>();

            if (orders != null)
            {
                foreach (var order in orders)
                {
                    var OrdersViewModel = new OrdersViewModel()
                    {
                        Id = order.Id,
                        Title = order.Title,
                        TypeOfProduct = order.TypeOfProduct,
                        Email = order.Email,
                        Price = order.Price
                    };
                    ordersList.Add(OrdersViewModel);
                }
                return View(ordersList);
            }
            return View(ordersList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrdersViewModel ordersData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orders = new Orders()
                    {
                        Title = ordersData.Title,
                        TypeOfProduct = ordersData.TypeOfProduct,
                        Email = ordersData.Email,
                        Price = ordersData.Price
                    };
                    _context.Orders.Add(orders);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Order created successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var orders = _context.Orders.SingleOrDefault(x => x.Id == Id);

                if (orders != null)
                {
                    var ordersView = new OrdersViewModel()
                    {
                        Id = orders.Id,
                        Title = orders.Title,
                        TypeOfProduct = orders.TypeOfProduct,
                        Email = orders.Email,
                        Price = orders.Price
                    };
                    return View(ordersView);
                }
                else
                {
                    TempData["errorMessage"] = $"Orders details not available with the Id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(OrdersViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orders = new Orders()
                    {
                        Id = model.Id,
                        Title = model.Title,
                        TypeOfProduct = model.TypeOfProduct,
                        Email = model.Email,
                        Price = model.Price
                    };
                    _context.Orders.Update(orders);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Orders details updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var orders = _context.Orders.SingleOrDefault(x => x.Id == Id);

                if (orders != null)
                {
                    var ordersView = new OrdersViewModel()
                    {
                        Id = orders.Id,
                        Title = orders.Title,
                        TypeOfProduct = orders.TypeOfProduct,
                        Email = orders.Email,
                        Price = orders.Price
                    };
                    return View(ordersView);
                }
                else
                {
                    TempData["errorMessage"] = $"Orders details not available with the Id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(OrdersViewModel model)
        {
            try
            {
                var orders = _context.Orders.SingleOrDefault(x => x.Id == model.Id);
                if (orders != null)
                {
                    _context.Orders.Remove(orders);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Order deleted successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Order details not available with the Id: {model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
