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

    public async Task<Order> Create(OrderCreateParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Order>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task<Order> Retrieve(OrderRetrieveParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Order>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task Delete(OrderDeleteParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Delete, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
