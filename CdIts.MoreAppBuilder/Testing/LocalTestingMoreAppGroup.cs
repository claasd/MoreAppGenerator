﻿namespace MoreAppBuilder.Testing;

public class LocalTestingMoreAppGroup(string name, string? idHint) : IGroupBuilder, IGroup
{
    public Task<IGroup> BuildAsync() => Task.FromResult<IGroup>(this);

    public string Id { get; } = idHint ?? "FakeId";
    public string Name { get; } = name;
}