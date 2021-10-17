using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCarStoreApiConsumer.Models;

namespace RazorPagesCarStoreApiConsumer.Pages.Cars
{
    public class EditCarModel : PageModel
    {
        private readonly ICarRepository _carRepository;

        public EditCarModel(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [BindProperty]
        public Car Car { get; set; }
        public async Task<IActionResult> OnGet(Guid storeId, Guid carId)
        {
            ViewData["StoreId"] = storeId;
            Car = await _carRepository.GetCar(storeId, carId);
            return Page();
        }
        public IActionResult OnPost(Guid storeId)
        {
            _carRepository.UpdateCar(storeId, Car);
            return RedirectToPage("/Stores/StoreList");
        }
    }
}
