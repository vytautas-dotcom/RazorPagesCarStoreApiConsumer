using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCarStoreApiConsumer.Models;

namespace RazorPagesCarStoreApiConsumer.Pages.Stores
{
    [BindProperties]
    public class StoreDetailsModel : PageModel
    {
        private readonly IStoreRepository _storeRepository;

        public StoreDetailsModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        
        public Store Store { get; set; }
        public int sold { get; set; }
        public async Task<IActionResult> OnGet(Guid storeId)
        {
            Store = await _storeRepository.UpdateStore(storeId, null);
            sold = Store.CarList.Count - (from cars in Store.CarList where cars.IsInStore == true select cars).ToList().Count;
            return Page();
        }
    }
}
