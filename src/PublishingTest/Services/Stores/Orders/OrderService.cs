using System.Net.Http;
using System.Threading.Tasks;
using PublishingTest.Core;
using PublishingTest.Models;
using PublishingTest.Models.Stores.Orders;

namespace PublishingTest.Services.Stores.Orders;

public sealed class OrderService : IOrderService
{
    readonly IPublishingTestClient _client;

    public OrderService(IPublishingTestClient client)
    {
        _client = client;
    }

    public async Task<Order> Create(OrderCreateParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<OrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Order>().ConfigureAwait(false);
    }

    public async Task<Order> Retrieve(OrderRetrieveParams parameters)
    {
        HttpRequest<OrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Order>().ConfigureAwait(false);
    }

    public async Task Delete(OrderDeleteParams parameters)
    {
        HttpRequest<OrderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
