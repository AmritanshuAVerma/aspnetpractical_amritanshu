using AlbumAPI.Services.Interfaces;
using AlbumAPI.Services.Models;
using AlbumAPI.Services.Utilities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace AlbumAPI.Services.Implementations
{
    internal class AlbumService : IAlbumService
    {
        private HttpClient httpClient;

        public AlbumService(IHttpClientFactory httpClientFactory)
        {
           httpClient = httpClientFactory.CreateClient(EndpointNames.Albums);
        }

        public async Task<List<AlbumDto>> GetAlbums(CancellationToken cancellationToken)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            var result = await httpClient.GetFromJsonAsync<ResponseWrapper<List<AlbumDto>>>("albums", options, cancellationToken);
            return result.Results ?? new List<AlbumDto>();
        }

       
    }
}