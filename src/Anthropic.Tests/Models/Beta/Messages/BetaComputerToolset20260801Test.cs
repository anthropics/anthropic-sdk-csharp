using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerToolset20260801Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CursorPosition = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("computer_toolset_20260801");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaComputerToolsetConfigs expectedConfigs = new()
        {
            CursorPosition = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedConfigs, model.Configs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CursorPosition = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolset20260801>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CursorPosition = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolset20260801>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("computer_toolset_20260801");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaComputerToolsetConfigs expectedConfigs = new()
        {
            CursorPosition = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedConfigs, deserialized.Configs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CursorPosition = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerToolset20260801 { };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Configs);
        Assert.False(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerToolset20260801 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaComputerToolset20260801 { CacheControl = null, Configs = null };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Configs);
        Assert.True(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComputerToolset20260801 { CacheControl = null, Configs = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CursorPosition = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        BetaComputerToolset20260801 copied = new(model);

        Assert.Equal(model, copied);
    }
}
