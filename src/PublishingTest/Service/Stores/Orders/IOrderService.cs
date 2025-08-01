using System.Threading.Tasks;
using PublishingTest.Models;
using PublishingTest.Models.Stores.Orders;

namespace PublishingTest.Service.Stores.Orders;

public interface IOrderService
{
    /// <summary>
    /// Place a new order in the store
    /// </summary>
    Task<Order> Create(OrderCreateParams @params);

    /// <summary>
    /// For valid response try integer IDs with value <= 5 or > 10. Other values will
    /// generate exceptions.
    /// </summary>
    Task<Order> Retrieve(OrderRetrieveParams @params);

    /// <summary>
    /// For valid response try integer IDs with value < 1000. Anything above 1000 or
    /// nonintegers will generate API errors
    /// </summary>
    Task Delete(OrderDeleteParams @params);
}
