using System.Threading.Tasks;

namespace PublishingTest.Tests.Services.Pets;

public class PetServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var pet = await this.client.Pets.Create(new() { Name = "doggie", PhotoURLs = ["string"] });
        pet.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var pet = await this.client.Pets.Retrieve(new() { PetID = 0 });
        pet.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var pet = await this.client.Pets.Update(new() { Name = "doggie", PhotoURLs = ["string"] });
        pet.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Pets.Delete(new() { PetID = 0 });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task FindByStatus_Works()
    {
        var pets = await this.client.Pets.FindByStatus(new());
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task FindByTags_Works()
    {
        var pets = await this.client.Pets.FindByTags(new());
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateByID_Works()
    {
        await this.client.Pets.UpdateByID(new() { PetID = 0 });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UploadImage_Works()
    {
        var response = await this.client.Pets.UploadImage(new() { PetID = 0 });
        response.Validate();
    }
}
