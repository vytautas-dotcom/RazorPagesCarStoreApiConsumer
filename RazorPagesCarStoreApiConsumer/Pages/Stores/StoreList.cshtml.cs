using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCarStoreApiConsumer.Models;

namespace RazorPagesCarStoreApiConsumer.Pages.Stores
{
    public class StoreListModel : PageModel
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICarRepository _carRepository;

        public StoreListModel(IStoreRepository storeRepository, ICarRepository carRepository)
        {
            _storeRepository = storeRepository;
            _carRepository = carRepository;
        }

        public IList<Store> Stores { get; set; }
        public async Task OnGet()
        {
            Stores = await _storeRepository.GetStoreList();
        }

        public async Task<IActionResult> OnPostDelete(Guid storeId)
        {
            await _storeRepository.DeleteStore(storeId);

            return RedirectToPage("./storelist");
        }
        public IActionResult OnPostDeleteCar(Guid storeId, Guid carId)
        {
            _carRepository.DeleteCar(storeId, carId);

            return RedirectToPage("./storelist");
        }
    }
}
