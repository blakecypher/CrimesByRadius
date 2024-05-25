using CrimeRadius.Model;
using CrimeRadius.Model.Interfaces;
using Newtonsoft.Json;

namespace CrimesByRadius.Service;
// lat=51.44237&lng=-2.49810&date=2021-01

public class CrimeService : ICrimeService
{
    private readonly HttpClient _httpClient = new();

    public async Task<IEnumerable<CrimeData>?> GetCrimeDataAsync(double latitude, double longitude, DateOnly dateTime)
    {
        var dateOnly = dateTime.ToString("yyyy-MM");
        var url = $"https://data.police.uk/api/crimes-street/all-crime?lat={latitude}&lng={longitude}&date={dateOnly}";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<CrimeData>>(content);
            }
            catch (JsonSerializationException ex)
            {
                Console.Write(ex.ToString());
            }
        }

        return null;
    }
}