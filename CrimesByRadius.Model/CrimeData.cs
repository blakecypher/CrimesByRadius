namespace CrimeRadius.Model;

[Serializable]
public class CrimeData
{
    public string category { get; set; }
    public string location_type { get; set; }
    public Location location { get; set; }
    public string context { get; set; }
    public OutcomeStatus outcome_status { get; set; } 
    public string persistent_id { get; set; }
    public int id { get; set; }
    public string location_subtype { get; set; }
    public string month { get; set; }
}