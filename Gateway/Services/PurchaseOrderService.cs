using Gateway.Data.Models;
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

    public Task<IEnumerable<PurchaseOrder>?> GetPurchaseOrdersAsync(int pageNumber, int pageSize)
    {
        return _poApiClient.GetPurchaseOrdersAsync(pageNumber, pageSize);
    }
}