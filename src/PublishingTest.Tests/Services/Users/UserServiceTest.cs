using System.Threading.Tasks;

namespace PublishingTest.Tests.Services.Users;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var user = await this.client.Users.Create();
        user.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var user = await this.client.Users.Retrieve(new() { Username = "username" });
        user.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Users.Update(new() { ExistingUsername = "username" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Users.Delete(new() { Username = "username" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateWithList_Works()
    {
        var user = await this.client.Users.CreateWithList();
        user.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Login_Works()
    {
        var response = await this.client.Users.Login();
        _ = response;
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Logout_Works()
    {
        await this.client.Users.Logout();
    }
}
