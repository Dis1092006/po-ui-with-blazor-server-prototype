using Gateway.Data;
using Gateway.Services.Api;

namespace Gateway.Services;

public class PurchaseOrderService : IPurchaseOrderService
{
    private readonly IPoApiClient _poApiClient;

    public PurchaseOrderService(IPoApiClient poApiClient)
    {
        _poApiClient = poApiClient;
    }

    public async Task<PurchaseOrder> GetPurchaseOrderAsync(int poNumber)
    {
        return await _poApiClient.GetPurchaseOrderAsync(poNumber);
    }

    public async Task<List<PurchaseOrder>> GetPurchaseOrdersAsync()
    {
        return await _poApiClient.GetPurchaseOrdersAsync();
    }
}