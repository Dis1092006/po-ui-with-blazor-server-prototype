using Gateway.Data;

namespace Gateway.Services.Api;

public interface IPoApiClient
{
    Task<PurchaseOrder> GetPurchaseOrderAsync(int id);
    
    Task<List<PurchaseOrder>> GetPurchaseOrdersAsync();
}