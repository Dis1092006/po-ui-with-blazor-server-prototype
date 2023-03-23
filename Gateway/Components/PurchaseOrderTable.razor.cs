using Gateway.Data.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Gateway.Components;

public partial class PurchaseOrderTable
{
    private IEnumerable<PurchaseOrder>? _purchaseOrders;
    private bool _isLoading = false;
    private int _count;

    [Inject]
    public IPurchaseOrderService PurchaseOrderService { get; set; }
    
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    async Task LoadData(LoadDataArgs args)
    {
        _isLoading = true;
        
        var pageSize = args.Top ?? 10;
        var pageNumber = (args.Skip ?? 0) / pageSize + 1;

        _purchaseOrders = await PurchaseOrderService.GetPurchaseOrdersAsync(pageNumber, pageSize);

        _count = 100;

        _isLoading = false;
    }
    
    private void ViewPoClicked(PurchaseOrder purchaseOrder)
    {
        NavigationManager.NavigateTo($"/purchase-order/{purchaseOrder.PoNumber}");
    }
}