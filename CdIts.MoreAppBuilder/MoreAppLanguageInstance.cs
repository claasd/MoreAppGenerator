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
    internal string Get(string section, string field, bool allowGlobal = true) => File.Get(section, field, Language, allowGlobal);
    internal string Get(string section, string field, string suffix, bool allowGlobal = true) => File.Get(section, field, Language+suffix, allowGlobal);
    public string FormName(string name) => File.Get(name, "__title", Language, false);
    public string FolderName(string name) => File.Get("__folders", name, Language, false);
}