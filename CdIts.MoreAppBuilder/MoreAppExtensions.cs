namespace MoreAppBuilder;

public static class MoreAppExtensions
{
    public static IHtmlElement AddCard(this IFormContainer form, string title, params string[] lines) => form.AddCard(CardType.Default, title, lines);
    public static IHtmlElement AddInfoCard(this IFormContainer form, string title, params string[] lines) => form.AddCard(CardType.Info, title, lines);
    public static IHtmlElement AddWarningCard(this IFormContainer form, string title, params string[] lines) => form.AddCard(CardType.Warning, title, lines);
    public static IHtmlElement AddErrorCard(this IFormContainer form, string title, params string[] lines) => form.AddCard(CardType.Error, title, lines);
    public static IHtmlElement AddSuccessCard(this IFormContainer form, string title, params string[] lines) => form.AddCard(CardType.Success, title, lines);
    public static IHtmlElement AddCardById(this IMultiLangFormContainer form, string id) => form.AddCardById(CardType.Default, id);
    public static IHtmlElement AddInfoCardById(this IMultiLangFormContainer form, string id) => form.AddCardById(CardType.Info, id);
    public static IHtmlElement AddWarningCardById(this IMultiLangFormContainer form, string id) => form.AddCardById(CardType.Warning, id);
    public static IHtmlElement AddErrorCardById(this IMultiLangFormContainer form, string id) => form.AddCardById(CardType.Error, id);
    public static IHtmlElement AddSuccessCardById(this IMultiLangFormContainer form, string id) => form.AddCardById(CardType.Success, id);
    public static IRadioElement TrueFalseRadio(this IFormContainer form, string id, string label, bool? defaultSelection = null, string trueString = "yes",  string falseString = "no") =>
    form.AddRadio(id, label).AddOption("true",  trueString, defaultSelection is true).AddOption("false", falseString, defaultSelection is false);
    public static IMultiLangRadioElement TrueFalseRadio(this IMultiLangFormContainer form, string id, bool? defaultSelection = null, string trueString = "yes",  string falseString = "no") =>
        form.AddRadio(id).AddOption("true", defaultSelection is true, "radio", trueString)
            .AddOption("false", defaultSelection is false, "radio", falseString);
    
    public static ICondition IsTrue(this IRadioElement radio) => radio.ValueIs("true");
    public static ICondition IsFalse(this IRadioElement radio) => radio.ValueIs("false");
    public static IRadioElement SetValueWhen(this IRadioElement radio, bool value, params ICondition[] conditions) => radio.SetValueWhen(value ?  "true" : "false", conditions);
    public static IRadioElement SetValueWhenAny(this IRadioElement radio, bool value, params ICondition[] conditions) => radio.SetValueWhenAny(value ?  "true" : "false", conditions);
    public static ICondition IsTrue(this IMultiLangRadioElement radio) => radio.ValueIs("true");
    public static ICondition IsFalse(this IMultiLangRadioElement radio) => radio.ValueIs("false");
    public static IMultiLangRadioElement SetValueWhen(this IMultiLangRadioElement radio, bool value, params ICondition[] conditions) => radio.SetValueWhen(value ?  "true" : "false", conditions);
    public static IMultiLangRadioElement SetValueWhenAny(this IMultiLangRadioElement radio, bool value, params ICondition[] conditions) => radio.SetValueWhenAny(value ?  "true" : "false", conditions);

}