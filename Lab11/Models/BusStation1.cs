using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "BusStations")]
public class BusStation
{
    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int BusStationID { get; set; }

    [Column]
    public string Name { get; set; }

    [Column]
    public string Location { get; set; }

    // Связь с Route
    public EntitySet<Route> Routes { get; set; }
}
