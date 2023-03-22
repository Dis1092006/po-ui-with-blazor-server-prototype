namespace Gateway.Data.Dto;

public class PoHistoryDto
{
    public string PoNumber { get; set; }
    public int ItemNumber { get; set; }
    public string LocalSku { get; set; }
    public int Quantity { get; set; }
    public float Cost { get; set; }
}