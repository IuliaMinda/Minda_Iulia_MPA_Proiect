using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minda_Iulia_Proiect.Data;
using Minda_Iulia_Proiect.Models;

namespace Minda_Iulia_Proiect.Controllers
{
    [Authorize]
    public class CardsController : Controller
    {
        private readonly RentalDbContext dbContext;

        public CardsController(RentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCardViewModel viewModel)
        {
            var card = new Card
            {
                Level = viewModel.Level
            };

            await dbContext.Cards.AddAsync(card);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Cards");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var cards = await dbContext.Cards.ToListAsync();

            return View(cards);
        }

        [HttpGet]
        public async Task <IActionResult> Edit(int id)
        {
            var card = await dbContext.Cards.FindAsync(id);

            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Card viewModel)
        {
            var card = await dbContext.Cards.FindAsync(viewModel.CardID);

            if(card is not null)
            {
                card.Level = viewModel.Level;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Cards");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Card viewModel)
        {
            var card = await dbContext.Cards.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CardID == viewModel.CardID);

            if(card is not null)
            {
                dbContext.Cards.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Cards");
        }
    }
}
