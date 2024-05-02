using System.Runtime.Serialization;

namespace MoreAppBuilder;

public enum Language
{
    [EnumMember(Value = "nl")] Nl,
    [EnumMember(Value = "en")] En,
    [EnumMember(Value = "es")] Es,
    [EnumMember(Value = "de")] De,
    [EnumMember(Value = "pt")] Pt,
    [EnumMember(Value = "fr")] Fr,
    [EnumMember(Value = "ca")] Ca
}
