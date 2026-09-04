using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolUnionTest : TestBase
{
    [Fact]
    public void BetaToolValidationWorks()
    {
        BetaToolUnion value = new BetaTool()
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [BetaToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = BetaToolType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void Bash20241022ValidationWorks()
    {
        BetaToolUnion value = new BetaToolBash20241022()
        {
            AllowedCallers = [BetaToolBash20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void Bash20250124ValidationWorks()
    {
        BetaToolUnion value = new BetaToolBash20250124()
        {
            AllowedCallers = [BetaToolBash20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20250522ValidationWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20250522()
        {
            AllowedCallers = [BetaCodeExecutionTool20250522AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20250825ValidationWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20250825()
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20260120ValidationWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20260120()
        {
            AllowedCallers = [BetaCodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20260521ValidationWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20260521()
        {
            AllowedCallers = [BetaCodeExecutionTool20260521AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BrowserToolset20260801ValidationWorks()
    {
        BetaToolUnion value = new BetaBrowserToolset20260801()
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
        value.Validate();
    }

    [Fact]
    public void ComputerUse20241022ValidationWorks()
    {
        BetaToolUnion value = new BetaToolComputerUse20241022()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void MemoryTool20250818ValidationWorks()
    {
        BetaToolUnion value = new BetaMemoryTool20250818()
        {
            AllowedCallers = [BetaMemoryTool20250818AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void ComputerUse20250124ValidationWorks()
    {
        BetaToolUnion value = new BetaToolComputerUse20250124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void TextEditor20241022ValidationWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20241022()
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void ComputerUse20251124ValidationWorks()
    {
        BetaToolUnion value = new BetaToolComputerUse20251124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20251124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            EnableZoom = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void ComputerToolset20260801ValidationWorks()
    {
        BetaToolUnion value = new BetaComputerToolset20260801()
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
        value.Validate();
    }

    [Fact]
    public void TextEditor20250124ValidationWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20250124()
        {
            AllowedCallers = [BetaToolTextEditor20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250429ValidationWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20250429()
        {
            AllowedCallers = [BetaToolTextEditor20250429AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250728ValidationWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20250728()
        {
            AllowedCallers = [BetaToolTextEditor20250728AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            MaxCharacters = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20250305ValidationWorks()
    {
        BetaToolUnion value = new BetaWebSearchTool20250305()
        {
            AllowedCallers = [BetaWebSearchTool20250305AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchTool20250910ValidationWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20250910()
        {
            AllowedCallers = [BetaWebFetchTool20250910AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20260209ValidationWorks()
    {
        BetaToolUnion value = new BetaWebSearchTool20260209()
        {
            AllowedCallers = [BetaWebSearchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchTool20260209ValidationWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20260209()
        {
            AllowedCallers = [BetaWebFetchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchTool20260309ValidationWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20260309()
        {
            AllowedCallers = [BetaWebFetchTool20260309AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
            UseCache = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20260318ValidationWorks()
    {
        BetaToolUnion value = new BetaWebSearchTool20260318()
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchTool20260318ValidationWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20260318()
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };
        value.Validate();
    }

    [Fact]
    public void AdvisorTool20260301ValidationWorks()
    {
        BetaToolUnion value = new BetaAdvisorTool20260301()
        {
            Model = Messages::Model.ClaudeFable5_1,
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxTokens = 1024,
            MaxUses = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void SearchToolBm25_20251119ValidationWorks()
    {
        BetaToolUnion value = new BetaToolSearchToolBm25_20251119()
        {
            Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void SearchToolRegex20251119ValidationWorks()
    {
        BetaToolUnion value = new BetaToolSearchToolRegex20251119()
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void McpToolsetValidationWorks()
    {
        BetaToolUnion value = new BetaMcpToolset()
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolSerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaTool()
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [BetaToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = BetaToolType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Bash20241022SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolBash20241022()
        {
            AllowedCallers = [BetaToolBash20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Bash20250124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolBash20250124()
        {
            AllowedCallers = [BetaToolBash20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20250522SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20250522()
        {
            AllowedCallers = [BetaCodeExecutionTool20250522AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20250825SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20250825()
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20260120SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20260120()
        {
            AllowedCallers = [BetaCodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20260521SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaCodeExecutionTool20260521()
        {
            AllowedCallers = [BetaCodeExecutionTool20260521AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BrowserToolset20260801SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaBrowserToolset20260801()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerUse20241022SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolComputerUse20241022()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryTool20250818SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaMemoryTool20250818()
        {
            AllowedCallers = [BetaMemoryTool20250818AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerUse20250124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolComputerUse20250124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20241022SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20241022()
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerUse20251124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolComputerUse20251124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20251124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            EnableZoom = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerToolset20260801SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaComputerToolset20260801()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20250124()
        {
            AllowedCallers = [BetaToolTextEditor20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250429SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20250429()
        {
            AllowedCallers = [BetaToolTextEditor20250429AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250728SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolTextEditor20250728()
        {
            AllowedCallers = [BetaToolTextEditor20250728AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            MaxCharacters = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20250305SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaWebSearchTool20250305()
        {
            AllowedCallers = [BetaWebSearchTool20250305AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20250910SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20250910()
        {
            AllowedCallers = [BetaWebFetchTool20250910AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20260209SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaWebSearchTool20260209()
        {
            AllowedCallers = [BetaWebSearchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20260209SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20260209()
        {
            AllowedCallers = [BetaWebFetchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20260309SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20260309()
        {
            AllowedCallers = [BetaWebFetchTool20260309AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
            UseCache = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20260318SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaWebSearchTool20260318()
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20260318SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaWebFetchTool20260318()
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdvisorTool20260301SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaAdvisorTool20260301()
        {
            Model = Messages::Model.ClaudeFable5_1,
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxTokens = 1024,
            MaxUses = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchToolBm25_20251119SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolSearchToolBm25_20251119()
        {
            Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchToolRegex20251119SerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaToolSearchToolRegex20251119()
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpToolsetSerializationRoundtripWorks()
    {
        BetaToolUnion value = new BetaMcpToolset()
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaToolUnion value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_control": {
                    "type": "ephemeral",
                    "ttl": "5m"
                  },
                  "defer_loading": true,
                  "strict": true,
                  "display_height_px": 1,
                  "display_width_px": 1,
                  "display_number": 0,
                  "max_uses": 1,
                  "user_location": {
                    "type": "approximate",
                    "city": "New York",
                    "country": "US",
                    "region": "California",
                    "timezone": "America/New_York"
                  },
                  "citations": {
                    "enabled": true
                  },
                  "max_content_tokens": 1,
                  "use_cache": true
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;
        long expectedDisplayHeightPx = 1;
        long expectedDisplayWidthPx = 1;
        long expectedDisplayNumber = 0;
        long expectedMaxUses = 1;
        BetaUserLocation expectedUserLocation = new()
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };
        long expectedMaxContentTokens = 1;
        bool expectedUseCache = true;

        Assert.Equal(expectedCacheControl, value.CacheControl);
        Assert.Equal(expectedDeferLoading, value.DeferLoading);
        Assert.Equal(expectedStrict, value.Strict);
        Assert.Equal(expectedDisplayHeightPx, value.DisplayHeightPx);
        Assert.Equal(expectedDisplayWidthPx, value.DisplayWidthPx);
        Assert.Equal(expectedDisplayNumber, value.DisplayNumber);
        Assert.Equal(expectedMaxUses, value.MaxUses);
        Assert.Equal(expectedUserLocation, value.UserLocation);
        Assert.Equal(expectedCitations, value.Citations);
        Assert.Equal(expectedMaxContentTokens, value.MaxContentTokens);
        Assert.Equal(expectedUseCache, value.UseCache);

        BetaToolUnion emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.CacheControl);
        Assert.Null(emptyValue.DeferLoading);
        Assert.Null(emptyValue.Strict);
        Assert.Null(emptyValue.DisplayHeightPx);
        Assert.Null(emptyValue.DisplayWidthPx);
        Assert.Null(emptyValue.DisplayNumber);
        Assert.Null(emptyValue.MaxUses);
        Assert.Null(emptyValue.UserLocation);
        Assert.Null(emptyValue.Citations);
        Assert.Null(emptyValue.MaxContentTokens);
        Assert.Null(emptyValue.UseCache);

        BetaToolUnion mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_control": [
                    "invalid"
                  ],
                  "defer_loading": [
                    "invalid"
                  ],
                  "strict": [
                    "invalid"
                  ],
                  "display_height_px": [
                    "invalid"
                  ],
                  "display_width_px": [
                    "invalid"
                  ],
                  "display_number": [
                    "invalid"
                  ],
                  "max_uses": [
                    "invalid"
                  ],
                  "user_location": [
                    "invalid"
                  ],
                  "citations": [
                    "invalid"
                  ],
                  "max_content_tokens": [
                    "invalid"
                  ],
                  "use_cache": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CacheControl);
        Assert.Null(mismatchedValue.DeferLoading);
        Assert.Null(mismatchedValue.Strict);
        Assert.Null(mismatchedValue.DisplayHeightPx);
        Assert.Null(mismatchedValue.DisplayWidthPx);
        Assert.Null(mismatchedValue.DisplayNumber);
        Assert.Null(mismatchedValue.MaxUses);
        Assert.Null(mismatchedValue.UserLocation);
        Assert.Null(mismatchedValue.Citations);
        Assert.Null(mismatchedValue.MaxContentTokens);
        Assert.Null(mismatchedValue.UseCache);
    }
}
