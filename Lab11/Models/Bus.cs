using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "Buses")]
public class Bus
{
    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int BusID { get; set; }

    [Column]
    public string BusNumber { get; set; }

    [Column]
    public int RouteID { get; set; }

    // Связь с Route
    private EntityRef<Route> _route;
    [Association(Storage = "_route", ThisKey = "RouteID", OtherKey = "RouteID")]
    public Route Route { get; set; }
}
