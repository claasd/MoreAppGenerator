using System.CodeDom.Compiler;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Primitives;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation;

public class ReverseReader
{
    public FormDto Form { get; }
    public FormVersionDto Version { get; }
    private int _elementCount = 1;
    private int _subFormCount = 0;

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
        _elementCount = 1;
        var stringBuilder = new StringBuilder("form:\n");
        stringBuilder.Append($"  __title:\n    {lang}:\n      title: '{Form.Meta.Name}'\n      description: '{Form.Meta.Description}'\n");
        int elementCount = 1;
        AddLangFields(Version.Fields, stringBuilder, lang);
        return stringBuilder.ToString();
    }

    private void AddLangFields(ICollection<Field> fields, StringBuilder stringBuilder, string lang, string prefix = "")
    {
        foreach (var field in fields)
        {
            var type = field.Widget.Split(":")[1];
            string? fieldName = null;
            if (field.Properties.TryGetValue("data_name", out var fieldNameValue))
                fieldName = fieldNameValue?.ToString();
            var label = "";
            if (field.Properties.TryGetValue("label_text", out var labelText) || field.Properties.TryGetValue("html_code", out labelText))
                label = labelText?.ToString();
            if (fieldName is null)
                fieldName = $"{type}{_elementCount++}";
            Dictionary<string, string> values = new();
            values.Add("title", label);
            if (IsHtmlSection(label, out var sectionTitle, out var sectionLines))
            {
                values["title"] = sectionTitle;
                if (sectionLines.Count == 0)
                    values["desc"] = "''";
                if(sectionLines.Count == 1)
                    values["desc"] = sectionLines[0];
                else
                    values["desc"] = "|\n          " + string.Join("\n          ", sectionLines);
            }
            
            if(HasStringValue(field, "add_button_text", out var buttonText))
                values.Add("button", buttonText);
            if(HasStringValue(field, "itemHtml", out var itemHtml))
                values.Add("desc", itemHtml);
            if ((field.Properties.TryGetValue("options", out var optionsValue) || field.Properties.TryGetValue("radio_options", out optionsValue)) &&
                optionsValue is JArray optionsArray)
            {
                foreach (var option in optionsArray)
                {
                    var id = option["id"].ToString();
                    var name = option["name"].ToString();
                    values.Add($"option.{id}", name);
                }
            }

            stringBuilder.Append($"  {prefix}{fieldName}:\n    {lang}:");
            if (values.Count == 1)
                stringBuilder.Append($" '{values.First().Value}'\n");
            else
            {
                stringBuilder.Append("\n");
                foreach (var (key, value) in values)
                {
                    stringBuilder.Append($"        {key}: {value}\n");
                }
            }

            if (type == "detail")
            {
                var subForm =  field.Properties["form"] as JObject;
                var subFormFields = subForm["fields"] as JArray;
                AddLangFields(subFormFields.Select(t=>t.ToObject<Field>()).ToList(), stringBuilder, lang, $"{prefix}{fieldName}.");       
            }
        }
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
        if (field.Properties.TryGetValue(flag, out var valueObj))
        {
            value = Convert.ToInt32(valueObj);
            return true;
        }

        value = 0;
        return false;
    }

    private string GenerateCode(bool useLangFile)
    {
        var stringBuilder = new StringBuilder("using MoreAppBuilder;\npublic static class FormBuilder{\n    public static void BuildForm(");
        if (useLangFile)
            stringBuilder.Append("IMultiLangFormBuilder form");
        else
            stringBuilder.Append("IFormBuilder form");
        stringBuilder.Append(", IDataSource dataSource){\n");
        int elementCount = 1;
        AddFields(Version.Fields, stringBuilder, useLangFile, "form");
        stringBuilder.Append("    }\n}\n");
        return stringBuilder.ToString();
    }

    private static string Escaped(string input)
    {
        return Microsoft.CodeAnalysis.CSharp.SymbolDisplay.FormatLiteral(input, true);
    }
    private void AddFields(ICollection<Field> fields, StringBuilder stringBuilder, bool useLangFile, string formName)
    {
        foreach (var field in fields)
        {
            var type = field.Widget.Split(":")[1];
            stringBuilder.Append("        ");
            string? fieldName = null;
            if (field.Properties.TryGetValue("data_name", out var fieldNameValue))
                fieldName = fieldNameValue?.ToString();
            var rawLabel = "";
            if (field.Properties.TryGetValue("label_text", out var labelText) || field.Properties.TryGetValue("html_code", out labelText))
                rawLabel = labelText.ToString();
            var label = Escaped(rawLabel);
            var methodName = "Add" + type[..1].ToUpper() + type[1..];
            if (methodName == "AddDatetime")
                methodName = "AddDateTime";
            if (type == "text_area")
                methodName = "AddTextArea";
            if (IsHtmlSection(rawLabel, out var sectionTitle, out var sectionLines))
                methodName = "AddHtmlSection";
            if (type == "detail")
            {
                _subFormCount++;
                stringBuilder.Append($"var subForm{_subFormCount} = form.AddSubForm(\"{fieldName}\"");
                if(!useLangFile)
                    stringBuilder.Append($", {label}");
                stringBuilder.Append(")");
            }
            else if (type == "htmlSection" && !useLangFile)
            {
                stringBuilder.Append($"{formName}.{methodName}({Escaped(sectionTitle)}");
                foreach (var sectionLine in sectionLines)
                    stringBuilder.Append($", {Escaped(sectionLine)}");
                stringBuilder.Append(")");
            }
            else if (type == "header" && useLangFile)
                stringBuilder.Append($"{formName}.AddHeaderById(\"header{_elementCount++}\", HeaderElementSize.{field.Properties["size"]?.ToString()?.ToUpper()})");
            else if (type == "header")
                stringBuilder.Append($"{formName}.AddHeader({label}, HeaderElementSize.{field.Properties["size"]?.ToString()?.ToUpper()})");
            else if (type == "timecalculation" && useLangFile)
                stringBuilder.Append($"{formName}.AddTimeCalculation(\"{fieldName}\", startElement, endElement)");
            else if (type == "timecalculation")
                stringBuilder.Append($"{formName}.AddTimeCalculation(\"{fieldName}\", {label}, startElement, endElement)");
            else if (type is "catalogue" or "search" && useLangFile)
                stringBuilder.Append($"{formName}.{methodName}(\"{fieldName}\", dataSource)");
            else if (type is "catalogue" or "search")
                stringBuilder.Append($"{formName}.{methodName}(\"{fieldName}\", {label}, dataSource)");
            else if (fieldName is null && useLangFile)
                stringBuilder.Append($"{formName}.{methodName}ById(\"{type}{_elementCount++}\")");
            else if (fieldName is null)
                stringBuilder.Append($"{formName}.{methodName}({label})");
            else if (useLangFile)
                stringBuilder.Append($"{formName}.{methodName}(\"{fieldName}\")");
            else
                stringBuilder.Append($"{formName}.{methodName}(\"{fieldName}\", {label})");


            if ((field.Properties.TryGetValue("options", out var optionsValue) || field.Properties.TryGetValue("radio_options", out optionsValue)) &&
                optionsValue is JArray optionsArray)
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

            if (HasStringValue(field, "text_placeholder", out var placeholder))
                stringBuilder.Append($".SetPlaceholder(\"{placeholder}\")");
            if (HasStringValue(field, "text_default_value", out var defaultValue))
                stringBuilder.Append($".SetDefault(\"{defaultValue}\")");
            if (HasStringValue(field, "default_value", out defaultValue))
                stringBuilder.Append($".SetDefault(\"{defaultValue}\")");
            if (HasIntValue(field, "min_length", out var minLength) && minLength > 0)
                stringBuilder.Append($".MinLength({minLength})");
            if (HasIntValue(field, "max_length", out var maxLength) && maxLength > 0)
                stringBuilder.Append($".MaxLength({maxLength})");
            if (HasIntValue(field, "min_items", out var minItems) && minItems > 0)
                stringBuilder.Append($".Minimum({minItems})");
            if (HasIntValue(field, "max_items", out var maxItems) && maxItems > 0)
                stringBuilder.Append($".Maximum({maxItems})");
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
            if (FlagIsTrue(field, "allow_barcode"))
                stringBuilder.Append(".AllowBarcode()");
            if (FlagIsTrue(field, "use_barcode_scanner"))
                stringBuilder.Append(".useBarcodeScanner()");
            if (HasStringValue(field, "currency", out var currency))
                stringBuilder.Append($".SetCurrency(\"{currency}\")");
            if (HasNumberValue(field, "vat_rate", out var vatRate))
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
                stringBuilder.Append(".Remember()");
            if(!useLangFile && HasStringValue(field,"add_button_text", out var buttonText))
                stringBuilder.Append($".AddButtonText(\"{buttonText}\")");
            if(!useLangFile && HasStringValue(field,"itemHtml", out var itemHtml))
                stringBuilder.Append($".ItemDescription(\"{itemHtml}\")");
            stringBuilder.Append(";\n");
            if (type == "detail")
            {
                var subForm =  field.Properties["form"] as JObject;
                var subFormFields = subForm["fields"] as JArray;
                AddFields(subFormFields.Select(t=>t.ToObject<Field>()).ToList(), stringBuilder, useLangFile, $"subForm{_subFormCount}");                
            }
        }
    }

    private bool IsHtmlSection(string label, out string title, out List<string> lines)
    {
        title = "";
        lines = [];
        if(!label.StartsWith("<hr/>") || !label.Contains("<p style=\"margin: 0\">") || !label.Contains("style=\"text-align:center\""))
            return false;
        var parts = label.Split("<p style=\"margin: 0\">");
        title = Regex.Replace(parts[0], "<.*?>", string.Empty).Trim();
        lines = parts.Skip(1).Select(p => Regex.Replace(p, "<.*?>", string.Empty).Trim()).Where(l=>!string.IsNullOrEmpty(l)).ToList();
        return true;
    }
}