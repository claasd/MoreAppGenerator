using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation.Model.Forms;

public class JsonPatch : List<JsonPatchOperation>
{
    public void AddReplace(string path, object value)
    {
        Add(new JsonPatchOperation
        {
            Operation = "replace",
            Path = path,
            Value = value
        });
    }
}

public class JsonPatchOperation
{
    [JsonProperty("op")]
    public string Operation { get; set; }
    [JsonProperty("path")]
    public string Path { get; set; }
    [JsonProperty("value")]
    public object Value { get; set; }
}