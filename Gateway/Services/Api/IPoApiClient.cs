using Gateway.Data.Models;

namespace Gateway.Services.Api;

public interface IPoApiClient
{
    Task<PurchaseOrder> GetPurchaseOrderAsync(int id);
    
    Task<List<PurchaseOrder>> GetPurchaseOrdersAsync();
}