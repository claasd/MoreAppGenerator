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
    internal string GetTitle(string section, string field, bool allowGlobal = true) => File.Get(section, field, Language, "title", allowGlobal: allowGlobal);
    internal string GetButton(string section, string field, bool allowGlobal = true) => File.Get(section, field, Language, "button", allowGlobal: allowGlobal);
    internal string GetDesc(string section, string field, bool allowGlobal = true) => File.Get(section, field, Language, "desc", allowGlobal: allowGlobal);
    internal string GetOption(string section, string field, string option, bool allowGlobal = true, string? globalConfigSection = null) => File.Get(section, field, Language, $"option.{option}", allowGlobal, globalConfigSection);
    public string FormName(string name) => GetTitle(name, "__title", false);
    public string FolderName(string name) => GetTitle("__folders", name, false);

    
}