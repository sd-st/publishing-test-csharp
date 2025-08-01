using System;
using System.Threading.Tasks;
using PublishingTest.Models.Store.Order.OrderCreateParamsProperties;

namespace PublishingTest.Tests.Service.Store.Order;

public class OrderServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var order = await this.client.Store.Order.Create(
            new()
            {
                ID = 10,
                Complete = true,
                PetID = 198772,
                Quantity = 7,
                ShipDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Approved,
            }
        );
        order.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var order = await this.client.Store.Order.Retrieve(new() { OrderID = 0 });
        order.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Store.Order.Delete(new() { OrderID = 0 });
    }
}
