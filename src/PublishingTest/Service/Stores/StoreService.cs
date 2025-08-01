using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PublishingTest.Models.Stores;
using Orders = PublishingTest.Service.Stores.Orders;

namespace PublishingTest.Service.Stores;

public sealed class StoreService : IStoreService
{
    readonly IPublishingTestClient _client;

    public StoreService(IPublishingTestClient client)
    {
        _client = client;
        _orders = new(() => new Orders::OrderService(client));
    }

    readonly Lazy<Orders::IOrderService> _orders;
    public Orders::IOrderService Orders
    {
        get { return _orders.Value; }
    }

    public async Task<Dictionary<string, int>> ListInventory(StoreListInventoryParams @params)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<Dictionary<string, int>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
