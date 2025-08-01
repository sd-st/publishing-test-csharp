using System.Threading.Tasks;
using PublishingTest.Models.Pet.PetCreateParamsProperties;
using PetUpdateParamsProperties = PublishingTest.Models.Pet.PetUpdateParamsProperties;

namespace PublishingTest.Tests.Service.Pet;

public class PetServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var pet = await this.client.Pet.Create(
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
    public async Task Update_Works()
    {
        var pet = await this.client.Pet.Update(
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
    public async Task FindByTags_Works()
    {
        var pets = await this.client.Pet.FindByTags(new() { Tags = ["string"] });
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact]
    public async Task UploadImage_Works()
    {
        var response = await this.client.Pet.UploadImage(
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
