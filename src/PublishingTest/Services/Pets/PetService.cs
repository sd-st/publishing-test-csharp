using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PublishingTest.Core;
using PublishingTest.Models.Pets;

namespace PublishingTest.Services.Pets;

public sealed class PetService : IPetService
{
    readonly IPublishingTestClient _client;

    public PetService(IPublishingTestClient client)
    {
        _client = client;
    }

    public async Task<Pet> Create(PetCreateParams parameters)
    {
        HttpRequest<PetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Pet>().ConfigureAwait(false);
    }

    public async Task<Pet> Retrieve(PetRetrieveParams parameters)
    {
        HttpRequest<PetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Pet>().ConfigureAwait(false);
    }

    public async Task<Pet> Update(PetUpdateParams parameters)
    {
        HttpRequest<PetUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Pet>().ConfigureAwait(false);
    }

    public async Task Delete(PetDeleteParams parameters)
    {
        HttpRequest<PetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<List<Pet>> FindByStatus(PetFindByStatusParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<PetFindByStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<List<Pet>>().ConfigureAwait(false);
    }

    public async Task<List<Pet>> FindByTags(PetFindByTagsParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<PetFindByTagsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<List<Pet>>().ConfigureAwait(false);
    }

    public async Task UpdateByID(PetUpdateByIDParams parameters)
    {
        HttpRequest<PetUpdateByIDParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<PetUploadImageResponse> UploadImage(PetUploadImageParams parameters)
    {
        HttpRequest<PetUploadImageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PetUploadImageResponse>().ConfigureAwait(false);
    }
}
