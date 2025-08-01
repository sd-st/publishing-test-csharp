using System.Collections.Generic;
using System.Threading.Tasks;
using PublishingTest.Models.Stores;
using Order = PublishingTest.Service.Stores.Order;

namespace PublishingTest.Service.Stores;

public interface IStoreService
{
    Order::IOrderService Order { get; }

    /// <summary>
    /// Returns a map of status codes to quantities
    /// </summary>
    Task<Dictionary<string, int>> ListInventory(StoreListInventoryParams @params);
}
