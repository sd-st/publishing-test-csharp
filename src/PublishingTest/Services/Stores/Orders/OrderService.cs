using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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

    public async Task<Order> Create(OrderCreateParams parameters)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(webRequest, this._client);
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
        return JsonSerializer.Deserialize<Order>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Order> Retrieve(OrderRetrieveParams parameters)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(webRequest, this._client);
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
        return JsonSerializer.Deserialize<Order>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task Delete(OrderDeleteParams parameters)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Delete, parameters.Url(this._client));
        parameters.AddHeadersToRequest(webRequest, this._client);
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
    }
}
