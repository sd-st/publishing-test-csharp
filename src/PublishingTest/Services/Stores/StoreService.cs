using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PublishingTest.Core;
using PublishingTest.Models.Stores;
using PublishingTest.Services.Stores.Orders;

namespace PublishingTest.Services.Stores;

public sealed class StoreService : IStoreService
{
    readonly IPublishingTestClient _client;

    public StoreService(IPublishingTestClient client)
    {
        _client = client;
        _orders = new(() => new OrderService(client));
    }

    readonly Lazy<IOrderService> _orders;
    public IOrderService Orders
    {
        get { return _orders.Value; }
    }

    public async Task<Dictionary<string, int>> ListInventory(
        StoreListInventoryParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<StoreListInventoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Dictionary<string, int>>().ConfigureAwait(false);
    }
}
