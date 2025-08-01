using System.Collections.Generic;
using System.Threading.Tasks;
using PublishingTest.Models.Pet;

namespace PublishingTest.Service.Pet;

public interface IPetService
{
    /// <summary>
    /// Add a new pet to the store
    /// </summary>
    Task<Pet> Create(PetCreateParams @params);

    /// <summary>
    /// Returns a single pet
    /// </summary>
    Task<Pet> Retrieve(PetRetrieveParams @params);

    /// <summary>
    /// Update an existing pet by Id
    /// </summary>
    Task<Pet> Update(PetUpdateParams @params);

    /// <summary>
    /// delete a pet
    /// </summary>
    Task Delete(PetDeleteParams @params);

    /// <summary>
    /// Multiple status values can be provided with comma separated strings
    /// </summary>
    Task<List<Pet>> FindByStatus(PetFindByStatusParams @params);

    /// <summary>
    /// Multiple tags can be provided with comma separated strings. Use tag1, tag2,
    /// tag3 for testing.
    /// </summary>
    Task<List<Pet>> FindByTags(PetFindByTagsParams @params);

    /// <summary>
    /// Updates a pet in the store with form data
    /// </summary>
    Task UpdateByID(PetUpdateByIDParams @params);

    /// <summary>
    /// uploads an image
    /// </summary>
    Task<PetUploadImageResponse> UploadImage(PetUploadImageParams @params);
}
