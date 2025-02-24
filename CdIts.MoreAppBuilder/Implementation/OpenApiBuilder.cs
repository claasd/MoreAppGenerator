using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation;

internal class OpenApiBuilder
{
    private List<string> _elements = new();

    public string Add(List<Element> elements, string name)
    {
        name = $"{name}DataObject";
        var builder = new StringBuilder();
        builder.AppendLine($"    {name}:\n      type: object\n      properties:");
        foreach (var element in elements)
        {
            if (!GetElementName(element, out var elementName))
                continue;
            
            builder.AppendLine($"        {elementName}:");
            var referenceType = GetReferenceType(element);
            if (element is IGenericFormContainer formContainer)
            {
                var newFormName = Add(formContainer.Elements, elementName);
                referenceType = newFormName;
            }
            
            if (referenceType != null)
            {
                builder.AppendLine($"          $ref: '#/components/schemas/{referenceType}'");
                continue;
            }

            var (type, format) = GetType(element);
            builder.AppendLine($"          type: {type}");
            if (format != null)
                builder.AppendLine($"          format: {format}");
            if (HasPredefinedValues(element, out var values))
                builder.AppendLine($"          enums: ['{string.Join("', '", values)}']");
        }

        _elements.Add(builder.ToString());
        return name;
    }

    private static bool HasPredefinedValues(Element element, out List<string> values)
    {
        values = [];
        if (!element.Field.Properties.TryGetValue("options", out var optionsValue) && !element.Field.Properties.TryGetValue("radio_options", out optionsValue))
            return false;
        if (optionsValue is JArray optionsArray)
        {
            values = optionsArray.Select(o => o["id"].ToString()).ToList();
            return true;
        }

        if (optionsValue is IEnumerable<LookupOption> options)
        {
            values = options.Select(o => o.Id).ToList();
            return true;
        }

        return false;
    }

    private static string? GetReferenceType(Element element)
    {
        var field = element.Field.Widget.Split(":")[1];
        return field switch
        {
            "location" => "MoreAppLocation",
            "photo" or "signature" => "MoreAppPhoto",
            "catalogue" => "MoreAppCatalogue",
            _ => null
        };
    }

    private static (string type, string? format) GetType(Element element)
    {
        var field = element.Field.Widget.Split(":")[1];
        return field switch
        {
            "checkbox" => ("boolean", null),
            "location" => ("MoreAppLocation", null),
            "photo" => ("MoreAppPhoto", null),
            "number" or "slider" or "rating" => ("integer", null),
            "date" => ("string", "date"),
            "datetime" => ("string", "date-time"),
            "time" => ("string", "time"),
            _ => ("string", null)
        };
    }

    private bool GetElementName(Element element, out string elementName)
    {
        elementName = "";
        if (!element.Field.Properties.TryGetValue("data_name", out var dataName))
            return false;
        if (dataName is not string name)
            return false;
        elementName = name;
        return true;
    }

    public string GenerateSpec()
    {
        var builder = new StringBuilder();
        builder.AppendLine("components:\n  schemas:\n");
        foreach (var element in _elements)
        {
            builder.Append(element);
        }

        return builder.ToString();
    }
}