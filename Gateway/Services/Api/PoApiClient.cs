using Gateway.Data.Dto;
using Gateway.Data.Models;
using Newtonsoft.Json;

namespace Gateway.Services.Api;

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
            var response = await _httpClient.GetAsync($"/api/v1/purchaseorders/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var dataResponse = JsonConvert.DeserializeObject<PurchaseOrderResponse>(json);

            var po = new PurchaseOrder
            {
                PoNumber = int.Parse(dataResponse.Data.Id),
                SupplierId = int.Parse(dataResponse.Data.Attributes.SupplierId),
                PoDate = DateTime.Parse(dataResponse.Data.Attributes.PoDate),
                Terms = dataResponse.Data.Attributes.Terms,
                Items = new List<PurchaseOrderItem>()
            };

            var poHistoryResponse = await _httpClient.GetAsync($"/api/v1/poHistory?filter=equals(poNumber,'{id}')");
            var jsonPoHistoryResponse = await poHistoryResponse.Content.ReadAsStringAsync();
            var contentPoHistoryResponse = JsonConvert.DeserializeObject<PoHistoryResponse>(jsonPoHistoryResponse);

            if (contentPoHistoryResponse?.Data != null)
                foreach (var item in contentPoHistoryResponse.Data)
                {
                    po.Items.Add(new PurchaseOrderItem
                    {
                        PoNumber = int.Parse(item.Id),
                        ItemNumber = item.Attributes.ItemNumber,
                        LocalSku = item.Attributes.LocalSku,
                        Quantity = item.Attributes.Quantity,
                        Cost = item.Attributes.Cost
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

    public async Task<List<PurchaseOrder>> GetPurchaseOrdersAsync()
    {
        var result = new List<PurchaseOrder>();
        var page = 1;
        var pageSize = 10;

        var response =
            await _httpClient.GetAsync(
                $"/api/v1/purchaseorders?sort=-poDate&page[size]={pageSize}&page[number]={page}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var dataResponse = JsonConvert.DeserializeObject<PurchaseOrdersResponse>(json);
        foreach (var purchaseOrderData in dataResponse.Data)
        {
            var po = new PurchaseOrder
            {
                PoNumber = int.Parse(purchaseOrderData.Id),
                SupplierId = int.Parse(purchaseOrderData.Attributes.SupplierId),
                PoDate = DateTime.Parse(purchaseOrderData.Attributes.PoDate),
                Items = new List<PurchaseOrderItem>()
            };
            result.Add(po);
        }

        return result;
    }
}