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
}