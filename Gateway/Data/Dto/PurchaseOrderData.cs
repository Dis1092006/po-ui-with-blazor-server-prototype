namespace Gateway.Data.Dto;

public class PurchaseOrderData
{
    public string Type { get; set; }
    public string Id { get; set; }
    public PurchaseOrdersDto Attributes { get; set; }
}