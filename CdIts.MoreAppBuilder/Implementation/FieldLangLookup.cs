namespace MoreAppBuilder.Implementation;

internal class FieldLangLookup
{
    private readonly MoreAppLanguageInstance _data;
    private readonly string _formId;
    private readonly string _field;

    internal FieldLangLookup(MoreAppLanguageInstance data, string formId, string field)
    {
        _data = data;
        _formId = formId;
        _field = field;
    }

    internal string GetOption(string optionName, bool allowGlobal = true, string? globalConfigSection = null, string? defaultValue = null) => _data.GetOption(_formId, _field, optionName, allowGlobal, globalConfigSection, defaultValue);
}