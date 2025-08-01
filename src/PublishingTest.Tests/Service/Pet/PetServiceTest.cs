using System.Threading.Tasks;
using PublishingTest.Models.Pet.PetFindByStatusParamsProperties;

namespace PublishingTest.Tests.Service.Pet;

public class PetServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var pet = await this.client.Pet.Retrieve(new() { PetID = 0 });
        pet.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Pet.Delete(new() { PetID = 0 });
    }

    [Fact]
    public async Task FindByStatus_Works()
    {
        var pets = await this.client.Pet.FindByStatus(new() { Status = Status.Available });
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact]
    public async Task UpdateByID_Works()
    {
        await this.client.Pet.UpdateByID(
            new()
            {
                PetID = 0,
                Name = "name",
                Status = "status",
            }
        );
    }
}
