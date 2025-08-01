using System.Collections.Generic;
using System.Threading.Tasks;
using PublishingTest.Models.Store;
using Order = PublishingTest.Service.Store.Order;

namespace PublishingTest.Service.Store;

public interface IStoreService
{
    Order::IOrderService Order { get; }

    /// <summary>
    /// Returns a map of status codes to quantities
    /// </summary>
    Task<Dictionary<string, int>> ListInventory(StoreListInventoryParams @params);
}
