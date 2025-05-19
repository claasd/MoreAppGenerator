namespace MoreAppBuilder.Debug;

public static class DevExtensions
{
    public static string CreateJsonDevData(this IFormInfo dataSource)
    {
        if (dataSource is DevFormBuilder builder1)
        {
            return DevFormBuilder.Json(builder1.Elements).ToString();
        }
        if (dataSource is DevMultiLangFormBuilder builder2)
        {
            return DevFormBuilder.Json(builder2.Elements).ToString();
        }
        throw new ArgumentException("DataSource must be of type DevFormBuilder");
    }
}