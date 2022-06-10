using Newtonsoft.Json;
using UserEqualizerWorkerService.PlaceHolder.Models;

namespace UserEqualizerWorkerService.Data.Api
{
    public class PlaceHolderClient
    {
        private readonly HttpClient _httpClient;

        public PlaceHolderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PlaceHolderUser>> GetPlaceHolderUsers()
        {
            var uri = "/users";

            var responseString = await _httpClient.GetStringAsync(uri);

            var placeHolederUsers = JsonConvert.DeserializeObject<List<PlaceHolderUser>>(responseString);

            return placeHolederUsers ?? new List<PlaceHolderUser>();
        }
    }
}