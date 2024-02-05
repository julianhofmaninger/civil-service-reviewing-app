using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;

namespace API.Services.PositionSync;

public class PositionSyncService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly HttpClient _httpClient;

    public PositionSyncService(ApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
    {
        _dbContext = dbContext;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task SyncDatabase(CancellationToken ct = default)
    {
        var positions = await DownloadPositionsAsync(ct);
        var mappedPositions = positions
            .Select(x => 
                x.FromContent());
        await _dbContext.Positions.AddRangeAsync(mappedPositions, ct);
        await _dbContext.SaveChangesAsync(ct);
    }

    private async Task<List<Content>> DownloadPositionsAsync(CancellationToken ct = default)
    {
        bool firstFetch = true;
        int positionCount = 1;
        
        List<Content> positions = [];
        for (int i = 0; i < positionCount; i+=100)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.zivildienst.gv.at/.rest/zisa/organisations/v1?limit=100&offset={i}");
            request.AddHeaders();
    
            var response = await _httpClient.SendAsync(request, ct);
            if (!response.IsSuccessStatusCode) 
                continue;
            var json = await response.Content.ReadAsStringAsync(ct);
            var data = JsonConvert.DeserializeObject<Root>(json);

            if (firstFetch && data != null)
            {
                positionCount = data.totalCount;
                firstFetch = false;
            }
            
            if (data?.content.Count == 0) 
                return positions;
            
            positions.AddRange(data?.content ?? Enumerable.Empty<Content>());
        }
        return positions;
    }
}