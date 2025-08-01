using System.Collections.Generic;
using System.Threading.Tasks;
using PublishingTest.Models.Stores;
using Orders = PublishingTest.Service.Stores.Orders;

namespace PublishingTest.Service.Stores;

public interface IStoreService
{
    Orders::IOrderService Orders { get; }

    /// <summary>
    /// Returns a map of status codes to quantities
    /// </summary>
    Task<Dictionary<string, int>> ListInventory(StoreListInventoryParams @params);
}
