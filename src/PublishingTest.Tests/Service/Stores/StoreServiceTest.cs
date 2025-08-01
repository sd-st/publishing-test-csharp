using System.Threading.Tasks;

namespace PublishingTest.Tests.Service.Stores;

public class StoreServiceTest : TestBase
{
    [Fact]
    public async Task ListInventory_Works()
    {
        var response = await this.client.Stores.ListInventory(new() { });
        foreach (var item in response.Values)
        {
            _ = item;
        }
    }
}
