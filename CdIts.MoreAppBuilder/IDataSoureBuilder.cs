namespace MoreAppBuilder;

public interface IDataSoureBuilder
{
    Task<IDataSource> BuildAsync();
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