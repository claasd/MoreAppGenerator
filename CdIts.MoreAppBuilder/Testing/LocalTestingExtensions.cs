namespace MoreAppBuilder.Testing;

public static class LocalTestingExtensions
{
    public static string CreateJsonDevData(this IFormInfo dataSource)
    {
        if (dataSource is LocalTestingFormBuilder builder1)
        {
            return LocalTestingFormBuilder.Json(builder1.Elements).ToString();
        }
        if (dataSource is DevMultiLangFormBuilder builder2)
        {
            return LocalTestingFormBuilder.Json(builder2.Elements).ToString();
        }
        throw new ArgumentException("DataSource must be of type DevFormBuilder");
    }
}