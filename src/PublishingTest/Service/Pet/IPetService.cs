using System.Collections.Generic;
using System.Threading.Tasks;
using PublishingTest.Models.Pet;

namespace PublishingTest.Service.Pet;

public interface IPetService
{
    /// <summary>
    /// Returns a single pet
    /// </summary>
    Task<Pet> Retrieve(PetRetrieveParams @params);

    /// <summary>
    /// delete a pet
    /// </summary>
    Task Delete(PetDeleteParams @params);

    /// <summary>
    /// Multiple status values can be provided with comma separated strings
    /// </summary>
    Task<List<Pet>> FindByStatus(PetFindByStatusParams @params);

    /// <summary>
    /// Updates a pet in the store with form data
    /// </summary>
    Task UpdateByID(PetUpdateByIDParams @params);
}
