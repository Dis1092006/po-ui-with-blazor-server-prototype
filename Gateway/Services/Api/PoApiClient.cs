using Gateway.Data;
using Newtonsoft.Json;

namespace Gateway.Services.Api;

public class PurchaseOrdersDto
{
    public string PoDate { get; set; }
    public string SupplierId { get; set; }
}

public class PoHistoryDto
{
    public string PoNumber { get; set; }
    public string ItemNumber { get; set; }
    public string LocalSku { get; set; }
    public string Quantity { get; set; }
    public string Cost { get; set; }
}

public class PurchaseOrdersData
{
    public string Type { get; set; }
    public string Id { get; set; }
    public PurchaseOrdersDto Attributes { get; set; }
}

public class PurchaseOrdersIncluded
{
    public string Type { get; set; }
    public string Id { get; set; }
    public PoHistoryDto Attributes { get; set; }
}

public class PoApiDataResponse
{
    public PurchaseOrdersData Data { get; set; }
    public PurchaseOrdersIncluded[] Included { get; set; }
}

public class PoApiClient : IPoApiClient
{
    private readonly HttpClient _httpClient;

    public PoApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PurchaseOrder> GetPurchaseOrderAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/v1/purchaseorders/{id}?include=poHistory");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var dataResponse = JsonConvert.DeserializeObject<PoApiDataResponse>(json);

            var po = new PurchaseOrder
            {
                PoNumber = int.Parse(dataResponse.Data.Id),
                SupplierId = int.Parse(dataResponse.Data.Attributes.SupplierId),
                PoDate = DateTime.Parse(dataResponse.Data.Attributes.PoDate),
                Items = new List<PurchaseOrderItem>()
            };

            foreach (var includedItem in dataResponse.Included)
            {
                po.Items.Add(new PurchaseOrderItem
                {
                    PoNumber = int.Parse(dataResponse.Data.Id),
                    ItemNumber = int.Parse(includedItem.Attributes.ItemNumber),
                    LocalSku = includedItem.Attributes.LocalSku,
                    Quantity = int.Parse(includedItem.Attributes.Quantity),
                    Cost = double.Parse(includedItem.Attributes.Cost)
                });
            }
            
            return po;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}