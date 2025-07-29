using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Testing;

public static class LocalTestingExtensions
{
    public static string CreateJsonDevData(this IFormInfo dataSource, JObject? testData = null)
    {
        if (dataSource is LocalTestingFormBuilder builder1)
        {
            return LocalTestingFormBuilder.Json(builder1.Elements, testData).ToString();
        }
        if (dataSource is DevMultiLangFormBuilder builder2)
        {
            return LocalTestingFormBuilder.Json(builder2.Elements, testData).ToString();
        }
        throw new ArgumentException("DataSource must be of type DevFormBuilder");
    }
}