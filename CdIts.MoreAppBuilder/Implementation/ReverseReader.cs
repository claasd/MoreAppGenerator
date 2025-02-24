using System.CodeDom.Compiler;
using System.Text;
using Microsoft.Extensions.Primitives;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation;

public class ReverseReader
{
    public FormDto Form { get; }
    public FormVersionDto Version { get; }

    public ReverseReader(FormDto form, FormVersionDto version)
    {
        Form = form;
        Version = version;
    }

    public MoreAppReadInfo Read(bool useLangFile, string lang = "en")
    {
        return new MoreAppReadInfo()
        {
            Code = GenerateCode(useLangFile),
            LangFile = GenerateLangFile(lang)
        };
    }

    private string GenerateLangFile(string lang)
    {
        var stringBuilder = new StringBuilder("form:\n");
        stringBuilder.Append($"  __title:\n    {lang}:\n      title: '{Form.Meta.Name}'\n      description: '{Form.Meta.Description}'\n");
        int elementCount = 1;
        foreach (var field in Version.Fields)
        {
            var type = field.Widget.Split(":")[1];
            string? fieldName = null;
            if (field.Properties.TryGetValue("data_name", out var fieldNameValue))
                fieldName = fieldNameValue?.ToString();
            var label = field.Properties["label_text"]?.ToString();
            if (fieldName is null)
                fieldName = $"{type}{elementCount++}";
            Dictionary<string, string> values = new();
            values.Add("title", label);
            if ((field.Properties.TryGetValue("options", out var optionsValue) || field.Properties.TryGetValue("radio_options", out optionsValue)) && optionsValue is JArray optionsArray)
            {
                foreach (var option in optionsArray)
                {
                    var id = option["id"].ToString();
                    var name = option["name"].ToString();
                    values.Add($"option.{id}", name);
                }
            }
            stringBuilder.Append($"  {fieldName}:\n    {lang}:");
            if(values.Count == 1)
                stringBuilder.Append($" '{values.First().Value}'\n");
            else
            {
                stringBuilder.Append("\n");
                foreach (var (key, value) in values)
                {
                    stringBuilder.Append($"        {key}: '{value}'\n");
                }
            }
        }
        return stringBuilder.ToString();
    }

    private static bool FlagIsTrue(Field field, string flag) => field.Properties.TryGetValue(flag, out var value) && value is true;

    private static bool HasStringValue(Field field, string flag, out string value)
    {
        if (field.Properties.TryGetValue(flag, out var valueObj) && valueObj is string stringValue && !string.IsNullOrWhiteSpace(stringValue))
        {
            value = stringValue;
            return true;
        }
        value = "";
        return false;
    }
    
    private static bool HasNumberValue(Field field, string flag, out double value)
    {
        if (field.Properties.TryGetValue(flag, out var valueObj))
        {
            value = Convert.ToDouble(valueObj);
            return true;
        }
        value = 0;
        return false;
    }
    
    private static bool HasIntValue(Field field, string flag, out int value)
    {
        if (field.Properties.TryGetValue(flag, out var valueObj) && valueObj is int intValue)
        {
            value = intValue;
            return true;
        }
        value = 0;
        return false;
    }

    private string GenerateCode(bool useLangFile)
    {
        var stringBuilder = new StringBuilder("using MoreAppBuilder;\npublic static class FormBuilder{\n    public static void BuildForm(");
        if(useLangFile)
            stringBuilder.Append("IMultiLangFormBuilder form");
        else
            stringBuilder.Append("IFormBuilder form");
        stringBuilder.Append(", IDataSource dataSource){\n");
        int elementCount = 1;
        foreach (var field in Version.Fields)
        {
            stringBuilder.Append("        ");
            var type = field.Widget.Split(":")[1];
            var methodName = "Add" + type[..1].ToUpper() + type[1..];
            if (methodName == "AddDatetime")
                methodName = "AddDateTime";
            if (type == "text_area")
                methodName = "AddTextArea";
            string? fieldName = null;
            if (field.Properties.TryGetValue("data_name", out var fieldNameValue))
                fieldName = fieldNameValue?.ToString();
            var label = field.Properties["label_text"]?.ToString();
            if (type == "header" && useLangFile)
                stringBuilder.Append($"form.AddHeaderById(\"header{elementCount++}\", HeaderElementSize.{field.Properties["size"]?.ToString()?.ToUpper()})");
            else if (type == "header")
                stringBuilder.Append($"form.AddHeader(\"{label}\", HeaderElementSize.{field.Properties["size"]?.ToString()?.ToUpper()})");
            else if (type == "timecalculation" && useLangFile)
                stringBuilder.Append($"form.AddTimeCalculation(\"{fieldName}\", startElement, endElement)");
            else if (type == "timecalculation")
                stringBuilder.Append($"form.AddTimeCalculation(\"{fieldName}\", \"{label}\", startElement, endElement)");
            else if (type == "catalogue" && useLangFile)
                stringBuilder.Append($"form.AddCatalogue(\"{fieldName}\", dataSource)");
            else if (type == "catalogue")
                stringBuilder.Append($"form.AddCatalogue(\"{fieldName}\", \"{label}\", dataSource)");
            else if (fieldName is null && useLangFile)
                stringBuilder.Append($"form.{methodName}ById(\"{type}{elementCount++}\")");
            else if (fieldName is null)
                stringBuilder.Append($"form.{methodName}(\"{label}\")");
            else if(useLangFile)
                stringBuilder.Append($"form.{methodName}(\"{fieldName}\")");
            else
                stringBuilder.Append($"form.{methodName}(\"{fieldName}\", \"{label}\")");


            if ((field.Properties.TryGetValue("options", out var optionsValue) || field.Properties.TryGetValue("radio_options", out optionsValue)) && optionsValue is JArray optionsArray)
            {
                foreach (var option in optionsArray)
                {
                    var id = option["id"].ToString();
                    var name = option["name"].ToString();
                    if (useLangFile)
                        stringBuilder.Append($".AddOption(\"{id}\")");
                    else
                        stringBuilder.Append($".AddOption(\"{id}\", \"{name}\")");
                }
            }
            if(HasStringValue(field, "text_placeholder", out var placeholder))
                stringBuilder.Append($".SetPlaceholder(\"{placeholder}\")");
            if(HasStringValue(field, "text_default_value", out var defaultValue))
                stringBuilder.Append($".SetDefault(\"{defaultValue}\")");
            if(HasIntValue(field, "min_length", out var minLength) && minLength > 0)
                stringBuilder.Append($".MinLength(\"{minLength}\")");
            if(HasIntValue(field, "max_length", out var maxLength) && maxLength > 0)
                stringBuilder.Append($".MaxLength(\"{maxLength}\")");
            if (FlagIsTrue(field, "initial_current_location"))
                stringBuilder.Append(".InitialCurrentLocation()");
            if (FlagIsTrue(field, "checkbox_default_value"))
                stringBuilder.Append(".CheckedAsDefault()");
            if (FlagIsTrue(field, "is_multiple"))
                stringBuilder.Append(".MultiSelection()");
            if (FlagIsTrue(field, "now_as_default"))
                stringBuilder.Append(".SetNowAsDefault()");
            if (FlagIsTrue(field, "show_prices"))
                stringBuilder.Append(".ShowPrices()");
            if (FlagIsTrue(field, "show_vat"))
                stringBuilder.Append(".ShowVat()");
            if (FlagIsTrue(field, "allow_remarks"))
                stringBuilder.Append(".AllowRemarks()");
            if (FlagIsTrue(field, "use_barcode_scanner"))
                stringBuilder.Append(".useBarcodeScanner()");
            if(HasStringValue(field, "currency", out var currency))
                stringBuilder.Append($".SetCurrency(\"{currency}\")");
            if(HasNumberValue(field, "vat_rate", out var vatRate))
                stringBuilder.Append($".SetVatRate({vatRate})");
            if (FlagIsTrue(field, "allow_library"))
                stringBuilder.Append(".AllowDeviceSelection()");
            if (HasStringValue(field, "quality", out var quality))
            {
                if (quality == "best")
                    stringBuilder.Append(".BestQuality()");
                else if (quality == "high")
                    stringBuilder.Append(".HighQuality()");
                else if (quality == "fast")
                    stringBuilder.Append(".FastUploadQuality()");
            }

            if (HasStringValue(field, "allowed_file_type", out var fileType))
            {
                var method = "For" + fileType[..1].ToUpper() + fileType[1..];
                stringBuilder.Append($".{method}()");
            }
                
                
            
            if (FlagIsTrue(field, "required"))
                stringBuilder.Append(".Required()");
            if (FlagIsTrue(field, "remember_input"))
                stringBuilder.Append(".RememberInput()");
            stringBuilder.Append(";\n");
        }

        stringBuilder.Append("    }\n}\n");
        return stringBuilder.ToString();
    }
}