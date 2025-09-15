namespace MoreAppBuilder;

public interface IDataSoureBuilder
{
    /// <param name="waitForCompletion">If set to true and this is a new data source, the method will block until the data source has valid colums or timeout has been reached</param>
    /// <param name="timeout">if left empty, a default timeout of 30 seconds will be used</param>
    /// <returns></returns>
    Task<IDataSource> BuildAsync(bool waitForCompletion = false, TimeSpan? timeout = null);
}

public interface IUrlDataSourceBuilder : IDataSoureBuilder
{
    IUrlDataSourceBuilder Header(string key, string value);
    IUrlDataSourceBuilder WeeklyUpdate();
    IUrlDataSourceBuilder DailyUpdate();
    IUrlDataSourceBuilder HourlyUpdate();
    IUrlDataSourceBuilder HalfHourlyUpdate();
    IUrlDataSourceBuilder QuarterHourlyUpdate();
}