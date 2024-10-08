﻿using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Core.Tokens;
using YamlDotNet.Serialization;

namespace MoreAppBuilder;

public record LanguageKey(string Section, string Field, string Language, string Key);

public class MoreAppLanguageFile
{
    private readonly IReadOnlyDictionary<string, string> _data;
    private bool _collectMissingKeys = false;
    public List<LanguageKey> MissingKeys { get; private set; } = []; 
    internal MoreAppLanguageFile(IReadOnlyDictionary<string, string> data)
    {
        _data = data;
    }

    public MoreAppLanguageInstance Language(string lang) => new MoreAppLanguageInstance(this, lang);


    public string Get(string section, string field, string language, string type, bool allowGlobal, string? globalConfigSection = null,
        string? defaultValue = null)
    {
        if (_data.TryGetValue(Key(section, field, language, type), out var value))
            return value;
        if (allowGlobal && _data.TryGetValue(Key("__global", globalConfigSection ?? field, language, type), out value))
            return value;
        if (defaultValue != null)
            return defaultValue;
        if (_collectMissingKeys)
        {
            MissingKeys.Add(new LanguageKey(section, field, language, type));
            return "<text missing>";
        }
        throw new KeyNotFoundException(
            $"Language file does not contain an entry for form {section}, field {field}, language {language}, type {type}");
    }

    public static MoreAppLanguageFile LoadYmlData(string data)
    {
        var deserializer = new Deserializer();
        var yamlObject = deserializer.Deserialize(data);
        return LoadJsonData(JsonConvert.SerializeObject(yamlObject));
    }

    public static string Key(string section, string field, string language, string key) => $"{section}/{field}/{language}/{key}";

    public static MoreAppLanguageFile LoadJsonData(string data)
    {
        var content = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, JToken>>>>(data);
        var contentDict = new Dictionary<string, string>();
        foreach (var (section, sectionData) in content!)
        {
            foreach (var (field, fieldData) in sectionData)
            {
                foreach (var (key, value) in fieldData)
                {
                    Dictionary<string, string> labels;
                    if (value.Type == JTokenType.String)
                    {
                        labels = new Dictionary<string, string>
                        {
                            ["title"] = value.ToString()
                        };
                    }
                    else
                    {
                        try
                        {
                            labels = value.ToObject<Dictionary<string, string>>()!;
                        }
                        catch (Exception e)
                        {
                            ;
                            throw;
                        }
                    }
                        

                    foreach (var label in labels)
                    {
                        contentDict[Key(section, field, key, label.Key)] = label.Value;
                    }

                    {
                    }
                }
            }
        }

        return new MoreAppLanguageFile(contentDict);
    }

    public MoreAppLanguageFile Merge(MoreAppLanguageFile other)
    {
        return new MoreAppLanguageFile(_data.Concat(other._data).DistinctBy(d => d.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
    }

    public void CollectMissingKeys(bool collect = true)
    {
        _collectMissingKeys = collect;
    }
}