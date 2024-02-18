using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minda_Iulia_Proiect.Data;
using Minda_Iulia_Proiect.Models;

namespace Minda_Iulia_Proiect.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly RentalDbContext dbContext;

        public CarsController(RentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel viewModel)
        {
            var car = new Car
            {
                RegistrationPlate = viewModel.RegistrationPlate,
                Make = viewModel.Make,
                Model = viewModel.Model
            };

            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Cars");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var cars = await dbContext.Cars.ToListAsync();

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await dbContext.Cars.FindAsync(id);

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Car viewModel)
        {
            var car = await dbContext.Cars.FindAsync(viewModel.CarID);

            if (car is not null)
            {
                car.RegistrationPlate = viewModel.RegistrationPlate;
                car.Make = viewModel.Make; 
                car.Model = viewModel.Model;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Cars");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Car viewModel)
        {
            var card = await dbContext.Cars.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CarID == viewModel.CarID);

            if (card is not null)
            {
                dbContext.Cars.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Cars");
        }
    }
}
