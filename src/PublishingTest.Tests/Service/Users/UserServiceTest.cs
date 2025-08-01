using System.Threading.Tasks;

namespace PublishingTest.Tests.Service.Users;

public class UserServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var user = await this.client.Users.Create(
            new()
            {
                ID = 10,
                Email = "john@email.com",
                FirstName = "John",
                LastName = "James",
                Password = "12345",
                Phone = "12345",
                Username = "theUser",
                UserStatus = 1,
            }
        );
        user.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var user = await this.client.Users.Retrieve(new() { Username = "username" });
        user.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Users.Update(
            new()
            {
                ExistingUsername = "username",
                ID = 10,
                Email = "john@email.com",
                FirstName = "John",
                LastName = "James",
                Password = "12345",
                Phone = "12345",
                Username = "theUser",
                UserStatus = 1,
            }
        );
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Users.Delete(new() { Username = "username" });
    }

    [Fact]
    public async Task CreateWithList_Works()
    {
        var user = await this.client.Users.CreateWithList(
            new()
            {
                Items =
                [
                    new()
                    {
                        ID = 10,
                        Email = "john@email.com",
                        FirstName = "John",
                        LastName = "James",
                        Password = "12345",
                        Phone = "12345",
                        Username = "theUser",
                        UserStatus = 1,
                    },
                ],
            }
        );
        user.Validate();
    }

    [Fact]
    public async Task Login_Works()
    {
        var response = await this.client.Users.Login(
            new() { Password = "password", Username = "username" }
        );
        _ = response;
    }

    [Fact]
    public async Task Logout_Works()
    {
        await this.client.Users.Logout(new() { });
    }
}
