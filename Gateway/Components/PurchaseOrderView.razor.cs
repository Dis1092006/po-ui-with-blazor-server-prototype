using Gateway.Data.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Components;

namespace Gateway.Components;

public partial class PurchaseOrderView
{
    private PurchaseOrder? PurchaseOrder { get; set; }

    [Inject] public IPurchaseOrderService PurchaseOrderService { get; set; }

    [Parameter]
    public int PoNumber { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PurchaseOrder = await PurchaseOrderService.GetPurchaseOrderAsync(PoNumber);
    }
}