using System.Threading.Tasks;

namespace PublishingTest.Tests.Services.Stores.Orders;

public class OrderServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var order = await this.client.Stores.Orders.Create(new());
        order.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var order = await this.client.Stores.Orders.Retrieve(new() { OrderID = 0 });
        order.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Stores.Orders.Delete(new() { OrderID = 0 });
    }
}
