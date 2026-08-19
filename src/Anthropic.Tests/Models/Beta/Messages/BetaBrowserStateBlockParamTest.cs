using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserStateBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            StateChanges = [new BetaBrowserStateChangeTabOpened("tab_id")],
        };

        List<BetaBrowserStateTabEntry> expectedTabs =
        [
            new()
            {
                TabID = "tab_id",
                Title = "title",
                Url = "url",
                Active = true,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("browser_state");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        List<BetaBrowserStateChange> expectedStateChanges =
        [
            new BetaBrowserStateChangeTabOpened("tab_id"),
        ];

        Assert.Equal(expectedTabs.Count, model.Tabs.Count);
        for (int i = 0; i < expectedTabs.Count; i++)
        {
            Assert.Equal(expectedTabs[i], model.Tabs[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.NotNull(model.StateChanges);
        Assert.Equal(expectedStateChanges.Count, model.StateChanges.Count);
        for (int i = 0; i < expectedStateChanges.Count; i++)
        {
            Assert.Equal(expectedStateChanges[i], model.StateChanges[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            StateChanges = [new BetaBrowserStateChangeTabOpened("tab_id")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            StateChanges = [new BetaBrowserStateChangeTabOpened("tab_id")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaBrowserStateTabEntry> expectedTabs =
        [
            new()
            {
                TabID = "tab_id",
                Title = "title",
                Url = "url",
                Active = true,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("browser_state");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        List<BetaBrowserStateChange> expectedStateChanges =
        [
            new BetaBrowserStateChangeTabOpened("tab_id"),
        ];

        Assert.Equal(expectedTabs.Count, deserialized.Tabs.Count);
        for (int i = 0; i < expectedTabs.Count; i++)
        {
            Assert.Equal(expectedTabs[i], deserialized.Tabs[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.NotNull(deserialized.StateChanges);
        Assert.Equal(expectedStateChanges.Count, deserialized.StateChanges.Count);
        for (int i = 0; i < expectedStateChanges.Count; i++)
        {
            Assert.Equal(expectedStateChanges[i], deserialized.StateChanges[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            StateChanges = [new BetaBrowserStateChangeTabOpened("tab_id")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.StateChanges);
        Assert.False(model.RawData.ContainsKey("state_changes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],

            CacheControl = null,
            StateChanges = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.StateChanges);
        Assert.True(model.RawData.ContainsKey("state_changes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],

            CacheControl = null,
            StateChanges = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserStateBlockParam
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            StateChanges = [new BetaBrowserStateChangeTabOpened("tab_id")],
        };

        BetaBrowserStateBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
