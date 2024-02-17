using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minda_Iulia_Proiect.Data;
using Minda_Iulia_Proiect.Models;

namespace Minda_Iulia_Proiect.Controllers
{
    public class CustomersController : Controller
    {
        private readonly RentalDbContext dbContext;

        public CustomersController(RentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel viewModel)
        {
            var customer = new Customer
            {
                CardID = viewModel.CardID,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };

            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customers =  await dbContext.Customers.ToListAsync();

            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer viewModel)
        {
            var customer = await dbContext.Customers.FindAsync(viewModel.CustomerID);

            if (customer is not null)
            {
                customer.CardID= viewModel.CardID; 
                customer.FirstName = viewModel.FirstName;
                customer.LastName = viewModel.LastName;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Customers");
        }
    }
}
