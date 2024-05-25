namespace CrimeRadius.Model.Interfaces;

public interface ICrimeService
{
    Task<IEnumerable<CrimeData>?> GetCrimeDataAsync(double latitude, double longitude, DateOnly dateTime);
}