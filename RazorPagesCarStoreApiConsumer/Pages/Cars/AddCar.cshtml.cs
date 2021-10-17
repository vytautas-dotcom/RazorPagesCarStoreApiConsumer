using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCarStoreApiConsumer.Models;

namespace RazorPagesCarStoreApiConsumer.Pages.Cars
{
    
    public class AddCarModel : PageModel
    {
        private readonly ICarRepository _carRepository;

        public AddCarModel(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [BindProperty]
        public Car Car { get; set; }
        public IActionResult OnGet(Guid storeId)
        {
            ViewData["StoreId"] = storeId;
            return Page();
        }

        public IActionResult OnPost(Guid storeId)
        {
            _carRepository.AddCar(storeId, Car);
            return RedirectToPage("/Stores/StoreList");
        }
    }
}
