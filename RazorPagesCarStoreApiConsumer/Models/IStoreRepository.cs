using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesCarStoreApiConsumer.Models
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetStoreList(Guid storeId = default);
        Task AddStore(Store store);
    }
}
