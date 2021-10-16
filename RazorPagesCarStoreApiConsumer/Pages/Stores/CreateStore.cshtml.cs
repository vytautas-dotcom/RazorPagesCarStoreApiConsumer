using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCarStoreApiConsumer.Models;

namespace RazorPagesCarStoreApiConsumer.Pages.Stores
{
    public class CreateStoreModel : PageModel
    {
        private readonly IStoreRepository _storeRepository;

        public CreateStoreModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [BindProperty]
        public Store Store { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _storeRepository.AddStore(Store);
            return RedirectToPage("./storelist");
        }
    }
}
