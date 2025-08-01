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
    /// Update an existing pet by Id
    /// </summary>
    Task<Pet> Update(PetUpdateParams @params);

    /// <summary>
    /// Multiple tags can be provided with comma separated strings. Use tag1, tag2,
    /// tag3 for testing.
    /// </summary>
    Task<List<Pet>> FindByTags(PetFindByTagsParams @params);

    /// <summary>
    /// uploads an image
    /// </summary>
    Task<PetUploadImageResponse> UploadImage(PetUploadImageParams @params);
}
