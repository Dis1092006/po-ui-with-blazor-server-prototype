using Gateway.Data.Models;

namespace Gateway.Services.Api;

public interface IPoApiClient
{
    Task<PurchaseOrder> GetPurchaseOrderAsync(int id);
    
    Task<IEnumerable<PurchaseOrder>?> GetPurchaseOrdersAsync(int pageNumber, int pageSize);
}