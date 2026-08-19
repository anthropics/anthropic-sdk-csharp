using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserToolset20260801Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("browser_toolset_20260801");
        List<ApiEnum<string, BetaBrowserToolset20260801AllowedCaller>> expectedAllowedCallers =
        [
            BetaBrowserToolset20260801AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaBrowserToolsetConfigs expectedConfigs = new()
        {
            CloseTab = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            FileUpload = new() { DeferLoading = true, Enabled = true },
            Find = new() { DeferLoading = true, Enabled = true },
            FormInput = new() { DeferLoading = true, Enabled = true },
            GetPageText = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Hover = new() { DeferLoading = true, Enabled = true },
            JavascriptExec = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            ListTabs = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            Navigate = new() { DeferLoading = true, Enabled = true },
            NewTab = new() { DeferLoading = true, Enabled = true },
            ReadConsole = new() { DeferLoading = true, Enabled = true },
            ReadNetwork = new() { DeferLoading = true, Enabled = true },
            ReadPage = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            ScrollTo = new() { DeferLoading = true, Enabled = true },
            SwitchTab = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedConfigs, model.Configs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolset20260801>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolset20260801>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("browser_toolset_20260801");
        List<ApiEnum<string, BetaBrowserToolset20260801AllowedCaller>> expectedAllowedCallers =
        [
            BetaBrowserToolset20260801AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaBrowserToolsetConfigs expectedConfigs = new()
        {
            CloseTab = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            FileUpload = new() { DeferLoading = true, Enabled = true },
            Find = new() { DeferLoading = true, Enabled = true },
            FormInput = new() { DeferLoading = true, Enabled = true },
            GetPageText = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Hover = new() { DeferLoading = true, Enabled = true },
            JavascriptExec = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            ListTabs = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            Navigate = new() { DeferLoading = true, Enabled = true },
            NewTab = new() { DeferLoading = true, Enabled = true },
            ReadConsole = new() { DeferLoading = true, Enabled = true },
            ReadNetwork = new() { DeferLoading = true, Enabled = true },
            ReadPage = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            ScrollTo = new() { DeferLoading = true, Enabled = true },
            SwitchTab = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedConfigs, deserialized.Configs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Configs);
        Assert.False(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],

            CacheControl = null,
            Configs = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Configs);
        Assert.True(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],

            CacheControl = null,
            Configs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserToolset20260801
        {
            AllowedCallers = [BetaBrowserToolset20260801AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new()
            {
                CloseTab = new() { DeferLoading = true, Enabled = true },
                DoubleClick = new() { DeferLoading = true, Enabled = true },
                FileUpload = new() { DeferLoading = true, Enabled = true },
                Find = new() { DeferLoading = true, Enabled = true },
                FormInput = new() { DeferLoading = true, Enabled = true },
                GetPageText = new() { DeferLoading = true, Enabled = true },
                HoldKey = new() { DeferLoading = true, Enabled = true },
                Hover = new() { DeferLoading = true, Enabled = true },
                JavascriptExec = new() { DeferLoading = true, Enabled = true },
                Key = new() { DeferLoading = true, Enabled = true },
                LeftClick = new() { DeferLoading = true, Enabled = true },
                LeftClickDrag = new() { DeferLoading = true, Enabled = true },
                LeftMouseDown = new() { DeferLoading = true, Enabled = true },
                LeftMouseUp = new() { DeferLoading = true, Enabled = true },
                ListTabs = new() { DeferLoading = true, Enabled = true },
                MiddleClick = new() { DeferLoading = true, Enabled = true },
                MouseMove = new() { DeferLoading = true, Enabled = true },
                Navigate = new() { DeferLoading = true, Enabled = true },
                NewTab = new() { DeferLoading = true, Enabled = true },
                ReadConsole = new() { DeferLoading = true, Enabled = true },
                ReadNetwork = new() { DeferLoading = true, Enabled = true },
                ReadPage = new() { DeferLoading = true, Enabled = true },
                RightClick = new() { DeferLoading = true, Enabled = true },
                Screenshot = new() { DeferLoading = true, Enabled = true },
                Scroll = new() { DeferLoading = true, Enabled = true },
                ScrollTo = new() { DeferLoading = true, Enabled = true },
                SwitchTab = new() { DeferLoading = true, Enabled = true },
                TripleClick = new() { DeferLoading = true, Enabled = true },
                Type = new() { DeferLoading = true, Enabled = true },
                Wait = new() { DeferLoading = true, Enabled = true },
                Zoom = new() { DeferLoading = true, Enabled = true },
            },
        };

        BetaBrowserToolset20260801 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaBrowserToolset20260801AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.Direct)]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.CodeExecution20250825)]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.CodeExecution20260120)]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.CodeExecution20260521)]
    public void Validation_Works(BetaBrowserToolset20260801AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserToolset20260801AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBrowserToolset20260801AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.Direct)]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.CodeExecution20250825)]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.CodeExecution20260120)]
    [InlineData(BetaBrowserToolset20260801AllowedCaller.CodeExecution20260521)]
    public void SerializationRoundtrip_Works(BetaBrowserToolset20260801AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserToolset20260801AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBrowserToolset20260801AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBrowserToolset20260801AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBrowserToolset20260801AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
