using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCarStoreApiConsumer.Models;

namespace RazorPagesCarStoreApiConsumer.Pages.Cars
{
    public class CarDetailsModel : PageModel
    {
        private readonly ICarRepository _carRepository;

        public CarDetailsModel(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [BindProperty]
        public Car Car { get; set; }
        public async Task<IActionResult> OnGet(Guid storeId, Guid carId)
        {
            Car = await _carRepository.GetCar(storeId, carId);
            return Page();
        }
    }
}
