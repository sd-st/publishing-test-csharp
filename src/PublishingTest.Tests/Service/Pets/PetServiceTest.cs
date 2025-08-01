using System.Threading.Tasks;
using PublishingTest.Models.Pets.PetCreateParamsProperties;
using PetFindByStatusParamsProperties = PublishingTest.Models.Pets.PetFindByStatusParamsProperties;
using PetUpdateParamsProperties = PublishingTest.Models.Pets.PetUpdateParamsProperties;

namespace PublishingTest.Tests.Service.Pets;

public class PetServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var pet = await this.client.Pets.Create(
            new()
            {
                Name = "doggie",
                PhotoURLs = ["string"],
                ID = 10,
                Category = new() { ID = 1, Name = "Dogs" },
                Status = Status.Available,
                Tags = [new() { ID = 0, Name = "name" }],
            }
        );
        pet.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var pet = await this.client.Pets.Retrieve(new() { PetID = 0 });
        pet.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var pet = await this.client.Pets.Update(
            new()
            {
                Name = "doggie",
                PhotoURLs = ["string"],
                ID = 10,
                Category = new() { ID = 1, Name = "Dogs" },
                Status = PetUpdateParamsProperties::Status.Available,
                Tags = [new() { ID = 0, Name = "name" }],
            }
        );
        pet.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Pets.Delete(new() { PetID = 0 });
    }

    [Fact]
    public async Task FindByStatus_Works()
    {
        var pets = await this.client.Pets.FindByStatus(
            new() { Status = PetFindByStatusParamsProperties::Status.Available }
        );
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact]
    public async Task FindByTags_Works()
    {
        var pets = await this.client.Pets.FindByTags(new() { Tags = ["string"] });
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact]
    public async Task UpdateByID_Works()
    {
        await this.client.Pets.UpdateByID(
            new()
            {
                PetID = 0,
                Name = "name",
                Status = "status",
            }
        );
    }

    [Fact]
    public async Task UploadImage_Works()
    {
        var response = await this.client.Pets.UploadImage(
            new()
            {
                PetID = 0,
                AdditionalMetadata = "additionalMetadata",
                Image = "a value",
            }
        );
        response.Validate();
    }
}
