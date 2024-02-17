using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minda_Iulia_Proiect.Data;
using Minda_Iulia_Proiect.Models;

namespace Minda_Iulia_Proiect.Controllers
{
    public class RentsController : Controller
    {
        private readonly RentalDbContext dbContext;

        public RentsController(RentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(AddRentViewModel viewModel)
        {
            var rent = new Rent
            {
                CarID = viewModel.CarID,
                CustomerID = viewModel.CustomerID,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate
            };

            await dbContext.Rents.AddAsync(rent);
            await dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var rents =  await dbContext.Rents.ToListAsync();

            return View(rents);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var rent = await dbContext.Rents.FindAsync(id);

            return View(rent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Rent viewModel)
        {
            var rent = await dbContext.Rents.FindAsync(viewModel.RentID);

            if (rent is not null)
            {
                rent.CustomerID = viewModel.CustomerID;
                rent.CarID = viewModel.CarID;
                rent.StartDate = viewModel.StartDate;
                rent.EndDate = viewModel.EndDate;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Rents");

        }
    }
}
