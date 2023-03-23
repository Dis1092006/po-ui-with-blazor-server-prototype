using Gateway.Data.Models;

namespace Gateway.Services;

public interface IPurchaseOrderService
{
    public Task<PurchaseOrder> GetPurchaseOrderAsync(int poNumber);

    public Task<IEnumerable<PurchaseOrder>?> GetPurchaseOrdersAsync(int pageNumber, int pageSize);
}