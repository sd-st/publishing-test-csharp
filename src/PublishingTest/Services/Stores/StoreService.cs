using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PublishingTest.Models.Stores;
using Orders = PublishingTest.Services.Stores.Orders;
using PublishingTest = PublishingTest;

namespace PublishingTest.Services.Stores;

public sealed class StoreService : IStoreService
{
    readonly PublishingTest::IPublishingTestClient _client;

    public StoreService(PublishingTest::IPublishingTestClient client)
    {
        _client = client;
        _orders = new(() => new Orders::OrderService(client));
    }

    readonly Lazy<Orders::IOrderService> _orders;
    public Orders::IOrderService Orders
    {
        get { return _orders.Value; }
    }

    public async Task<Dictionary<string, int>> ListInventory(StoreListInventoryParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new PublishingTest::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Dictionary<string, int>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                PublishingTest::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
