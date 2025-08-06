using System.Collections.Generic;
using System.Threading.Tasks;
using PublishingTest.Models.Pets;

namespace PublishingTest.Services.Pets;

public interface IPetService
{
    /// <summary>
    /// Add a new pet to the store
    /// </summary>
    Task<Pet> Create(PetCreateParams parameters);

    /// <summary>
    /// Returns a single pet
    /// </summary>
    Task<Pet> Retrieve(PetRetrieveParams parameters);

    /// <summary>
    /// Update an existing pet by Id
    /// </summary>
    Task<Pet> Update(PetUpdateParams parameters);

    /// <summary>
    /// delete a pet
    /// </summary>
    Task Delete(PetDeleteParams parameters);

    /// <summary>
    /// Multiple status values can be provided with comma separated strings
    /// </summary>
    Task<List<Pet>> FindByStatus(PetFindByStatusParams parameters);

    /// <summary>
    /// Multiple tags can be provided with comma separated strings. Use tag1, tag2,
    /// tag3 for testing.
    /// </summary>
    Task<List<Pet>> FindByTags(PetFindByTagsParams parameters);

    /// <summary>
    /// Updates a pet in the store with form data
    /// </summary>
    Task UpdateByID(PetUpdateByIDParams parameters);

    /// <summary>
    /// uploads an image
    /// </summary>
    Task<PetUploadImageResponse> UploadImage(PetUploadImageParams parameters);
}
