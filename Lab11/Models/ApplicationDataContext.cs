using System.Data.Linq;

namespace Lab11
{
    public class ApplicationDataContext : DataContext
    {
        const string _connectionString = @"Server=RAQSHKA\SQLEXPRESS;Database=Lab11;Trusted_Connection=Yes;";
        public Table<BusStation> BusStations;
        public Table<Route> Routes;
        public Table<Bus> Buses;
        public ApplicationDataContext(string connectionString=_connectionString) : base(connectionString) {
        }
    }
}