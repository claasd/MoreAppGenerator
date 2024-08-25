using System.Collections.ObjectModel;
using Newtonsoft.Json;
using YamlDotNet.Core.Tokens;
using YamlDotNet.Serialization;

namespace MoreAppBuilder;


public class MoreAppLanguageFile
{
    private readonly IReadOnlyDictionary<string, string> _data;
    private string[] _suffixesToIgnore = [];

    internal MoreAppLanguageFile(IReadOnlyDictionary<string, string> data)
    {
        _data = data;
    }

    public MoreAppLanguageInstance Language(string lang) => new MoreAppLanguageInstance(this, lang);
    

    public string Get(string section, string field, string language, bool allowGlobal)
    {
        foreach (var suffixToIgnore in _suffixesToIgnore)
        {
            if(field.EndsWith(suffixToIgnore))
                field = field[..^(suffixToIgnore.Length+1)];
            if(section.EndsWith(suffixToIgnore))
                section = section[..^(suffixToIgnore.Length+1)];
            section = section.Replace($"{suffixToIgnore}.", ".");
            field = field.Replace($"{suffixToIgnore}.", ".");
        }
        
        if (_data.TryGetValue(Key(section, field, language), out var value))
            return value;
        if (allowGlobal && _data.TryGetValue(Key("__global", field, language), out value))
            return value;
        throw new KeyNotFoundException($"Language file does not contain an entry for form {section}, field {field}, language {language}");
        
    }
    
    public static MoreAppLanguageFile LoadYmlData(string data)
    {
        var deserializer = new Deserializer();
        var yamlObject = deserializer.Deserialize(data);
        return LoadJsonData(JsonConvert.SerializeObject(yamlObject));
    }
    public static string Key(string section, string field, string key) => $"{section}/{field}/{key}";

    public static MoreAppLanguageFile LoadJsonData(string data)
    {
        var content = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(data);
        var contentDict = new Dictionary<string, string>();
        foreach (var (section, sectionData) in content!)
        {
            foreach (var (field, fieldData) in sectionData)
            {
                foreach (var (key, value) in fieldData)
                {
                    contentDict[Key(section, field, key)] = value;
                }
            }

        }
        return new MoreAppLanguageFile(contentDict);
    }


    public void AddSuffixToIgnore(params string[] suffixes)
    {
        _suffixesToIgnore = suffixes;
    }
}