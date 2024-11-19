using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "Routes")]
public class Route
{
    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int RouteID { get; set; }

    [Column]
    public string RouteName { get; set; }

    [Column]
    public int OriginStationID { get; set; }

    [Column]
    public int DestinationStationID { get; set; }

    // Связь с BusStation (Origin и Destination)
    private EntityRef<BusStation> _originStation;
    [Association(Storage = "_originStation", ThisKey = "OriginStationID", OtherKey = "BusStationID")]
    public BusStation OriginStation { get; set; }

    private EntityRef<BusStation> _destinationStation;
    [Association(Storage = "_destinationStation", ThisKey = "DestinationStationID", OtherKey = "BusStationID")]
    public BusStation DestinationStation { get; set; }

    // Связь с Bus
    public EntitySet<Bus> Buses { get; set; }
}
