using System.Threading.Tasks;

namespace PublishingTest.Tests.Service.Store;

public class StoreServiceTest : TestBase
{
    [Fact]
    public async Task ListInventory_Works()
    {
        var response = await this.client.Store.ListInventory(new() { });
        foreach (var item in response.Values)
        {
            _ = item;
        }
    }
}
