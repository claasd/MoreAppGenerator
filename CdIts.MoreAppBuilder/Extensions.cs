namespace MoreAppBuilder;

public static class Extensions
{
    public static ICondition[] With(this ICondition condition, ICondition other) => [condition, other];
    public static ICondition[] With(this ICondition[] condition, ICondition other) => condition.Append(other).ToArray();
    public static ICondition[] With(this ICondition condition, ICondition[] other) => other.With(condition);
    public static ICondition[] With(this ICondition[] condition, ICondition[] other) => condition.Concat(other).ToArray();
}