namespace Gateway.Data.Models;

public class PurchaseOrder
{
    public int PoNumber { get; set; }

    public int SupplierId { get; set; }
    
    public DateTime PoDate { get; set; }
    
    public string Terms { get; set; }
    
    public List<PurchaseOrderItem> Items { get; set; }
}