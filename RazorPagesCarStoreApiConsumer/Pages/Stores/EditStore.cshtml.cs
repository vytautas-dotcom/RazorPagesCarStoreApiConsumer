using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCarStoreApiConsumer.Models;

namespace RazorPagesCarStoreApiConsumer.Pages.Stores
{
    public class EditStoreModel : PageModel
    {
        private readonly IStoreRepository _storeRepository;

        public EditStoreModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [BindProperty]
        public Store Store { get; set; }
        public async Task<IActionResult> OnGet(Guid storeId)
        {
            Store = await _storeRepository.UpdateStore(storeId, null);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _storeRepository.UpdateStore(Store.Id, Store);

            return RedirectToPage("./storelist");
        }
    }
}
