namespace petStoreMonitoringApp.Models.ViewModels
{
    public class PerformanceMetricsVM
    {
        // Raw data
        public List<Session> SessionsList { get; set; }

        // Aggregated data
        public Dictionary<int, int> TotalNumbersOfSessions { get; set; }
        public Dictionary<int, double> AverageResponseTimes { get; set; }
        public Dictionary<int, double> AverageSessionLengths { get; set; }
    }
}
