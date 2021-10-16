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

        public StoreListModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IList<Store> Stores { get; set; }
        public async Task OnGet()
        {
            Stores = await _storeRepository.GetStoreList();
        }
    }
}
