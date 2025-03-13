using System.Net;

namespace MoreAppBuilder;

public class MoreAppLanguageInstance
{
    internal MoreAppLanguageFile File { get; }
    public string Language { get; }

    internal MoreAppLanguageInstance(MoreAppLanguageFile file, string language)
    {
        File = file;
        Language = language;
    }
    public string GetByType(string section, string field, string type, bool allowGlobal = true) => File.Get(section, field, Language, type, allowGlobal: allowGlobal);
    public string GetTitle(string section, string field, bool allowGlobal = true) => File.Get(section, field, Language, "title", allowGlobal: allowGlobal);
    public string GetButton(string section, string field, bool allowGlobal = true) => File.Get(section, field, Language, "button", allowGlobal: allowGlobal);
    public string GetDesc(string section, string field, bool allowGlobal = true) => File.Get(section, field, Language, "desc", allowGlobal: allowGlobal);
    public string GetOption(string section, string field, string option, bool allowGlobal = true, string? globalConfigSection = null, string? defaultValue = null) => File.Get(section, field, Language, $"option.{option}", allowGlobal, globalConfigSection, defaultValue);
    public string FormName(string name) => GetTitle(name, "__title", false);
    public string FormDesc(string name) => GetDesc(name, "__title", false);
    public string FolderName(string name) => GetTitle("__folders", name, false);
    public string FolderDesc(string name) => GetDesc("__folders", name, false);

    
}