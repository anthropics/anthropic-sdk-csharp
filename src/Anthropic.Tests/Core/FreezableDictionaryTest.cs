using System;
using System.Collections.Generic;
using Anthropic.Core;

namespace Anthropic.Tests.Core;

public class FreezableDictionaryTest : TestBase
{
    [Fact]
    public void Unfrozen_Works()
    {
        var freezable = new FreezableDictionary<string, string>();
        Assert.Throws<KeyNotFoundException>(() => freezable["foo"]);
        freezable["foo"] = "bar";
        Assert.Equal("bar", freezable["foo"]);

        // overwriting key
        freezable["foo"] = "baz";
        Assert.Equal("baz", freezable["foo"]);

        // inserting new key
        freezable["bar"] = "foo";
        Assert.Equal("foo", freezable["bar"]);

        Assert.Equal("baz", freezable["foo"]);
    }

    [Fact]
    public void Frozen_Works()
    {
        var freezable = new FreezableDictionary<string, string>() { ["foo"] = "bar" };
        Assert.Equal("bar", freezable.Freeze()["foo"]);
        Assert.Equal("bar", freezable["foo"]);
        Assert.Throws<KeyNotFoundException>(() => freezable["bar"]);
        Assert.Throws<KeyNotFoundException>(() => freezable.Freeze()["bar"]);

        // overwriting key
        Assert.Throws<InvalidOperationException>(() => freezable["foo"] = "baz");

        // inserting new key
        Assert.Throws<InvalidOperationException>(() => freezable["baz"] = "buzz");
    }
}
