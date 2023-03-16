using Gateway.Data;
using Gateway.Services.Api;

namespace Gateway.Services;

public class PurchaseOrderService : IPurchaseOrderService
{
    public PurchaseOrderService(IPoApiClient poApiClient)
    {
    }

    public Task<PurchaseOrder> GetPurchaseOrderAsync(int poNumber)
    {
        return Task.FromResult(new PurchaseOrder
        {
            PoNumber = poNumber,
            SupplierId = 1,
            PoDate = DateTime.Now,
            Items = new List<PurchaseOrderItem>
            {
                new PurchaseOrderItem
                {
                    PoNumber = poNumber,
                    ItemNumber = 1,
                    LocalSku = "ITEM-1",
                    Quantity = 2,
                    Cost = 1.12
                },
                new PurchaseOrderItem
                {
                    PoNumber = poNumber,
                    ItemNumber = 2,
                    LocalSku = "ITEM-2",
                    Quantity = 4,
                    Cost = 2.34
                }
            }
        });
    }

    public Task<List<PurchaseOrder>> GetPurchaseOrdersAsync()
    {
        var result = new List<PurchaseOrder>();
        result.Add(new PurchaseOrder
        {
            PoNumber = 1,
            SupplierId = 1,
            PoDate = DateTime.Now,
            Items = new List<PurchaseOrderItem>
            {
                new PurchaseOrderItem
                {
                    PoNumber = 1,
                    ItemNumber = 1,
                    LocalSku = "ITEM-1",
                    Quantity = 2,
                    Cost = 1.12
                },
                new PurchaseOrderItem
                {
                    PoNumber = 1,
                    ItemNumber = 2,
                    LocalSku = "ITEM-2",
                    Quantity = 4,
                    Cost = 2.34
                }
            }
        });

        return Task.FromResult(result);
    }
}