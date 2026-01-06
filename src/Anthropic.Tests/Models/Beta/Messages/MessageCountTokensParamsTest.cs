using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class MessageCountTokensParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MessageCountTokensParamsSystem value = new("string");
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamsValidationWorks()
    {
        MessageCountTokensParamsSystem value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MessageCountTokensParamsSystem value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensParamsSystem>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextBlockParamsSerializationRoundtripWorks()
    {
        MessageCountTokensParamsSystem value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensParamsSystem>(element);

        Assert.Equal(value, deserialized);
    }
}

public class ToolTest : TestBase
{
    [Fact]
    public void BetaValidationWorks()
    {
        Tool value = new(
            new BetaTool()
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
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = BetaToolType.Custom,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolBash20241022ValidationWorks()
    {
        Tool value = new(
            new BetaToolBash20241022()
            {
                AllowedCallers = [BetaToolBash20241022AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolBash20250124ValidationWorks()
    {
        Tool value = new(
            new BetaToolBash20250124()
            {
                AllowedCallers = [BetaToolBash20250124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaCodeExecutionTool20250522ValidationWorks()
    {
        Tool value = new(
            new BetaCodeExecutionTool20250522()
            {
                AllowedCallers = [AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaCodeExecutionTool20250825ValidationWorks()
    {
        Tool value = new(
            new BetaCodeExecutionTool20250825()
            {
                AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolComputerUse20241022ValidationWorks()
    {
        Tool value = new(
            new BetaToolComputerUse20241022()
            {
                DisplayHeightPx = 1,
                DisplayWidthPx = 1,
                AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaMemoryTool20250818ValidationWorks()
    {
        Tool value = new(
            new BetaMemoryTool20250818()
            {
                AllowedCallers = [BetaMemoryTool20250818AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolComputerUse20250124ValidationWorks()
    {
        Tool value = new(
            new BetaToolComputerUse20250124()
            {
                DisplayHeightPx = 1,
                DisplayWidthPx = 1,
                AllowedCallers = [BetaToolComputerUse20250124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20241022ValidationWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20241022()
            {
                AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolComputerUse20251124ValidationWorks()
    {
        Tool value = new(
            new BetaToolComputerUse20251124()
            {
                DisplayHeightPx = 1,
                DisplayWidthPx = 1,
                AllowedCallers = [BetaToolComputerUse20251124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20250124ValidationWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20250124()
            {
                AllowedCallers = [BetaToolTextEditor20250124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20250429ValidationWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20250429()
            {
                AllowedCallers = [BetaToolTextEditor20250429AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20250728ValidationWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20250728()
            {
                AllowedCallers = [BetaToolTextEditor20250728AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebSearchTool20250305ValidationWorks()
    {
        Tool value = new(
            new BetaWebSearchTool20250305()
            {
                AllowedCallers = [BetaWebSearchTool20250305AllowedCaller.Direct],
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchTool20250910ValidationWorks()
    {
        Tool value = new(
            new BetaWebFetchTool20250910()
            {
                AllowedCallers = [BetaWebFetchTool20250910AllowedCaller.Direct],
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                DeferLoading = true,
                MaxContentTokens = 1,
                MaxUses = 1,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolBm25_20251119ValidationWorks()
    {
        Tool value = new(
            new BetaToolSearchToolBm25_20251119()
            {
                Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
                AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolRegex20251119ValidationWorks()
    {
        Tool value = new(
            new BetaToolSearchToolRegex20251119()
            {
                Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
                AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaMCPToolsetValidationWorks()
    {
        Tool value = new(
            new BetaMCPToolset()
            {
                MCPServerName = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Configs = new Dictionary<string, BetaMCPToolConfig>()
                {
                    {
                        "foo",
                        new() { DeferLoading = true, Enabled = true }
                    },
                },
                DefaultConfig = new() { DeferLoading = true, Enabled = true },
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaSerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaTool()
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
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = BetaToolType.Custom,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolBash20241022SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolBash20241022()
            {
                AllowedCallers = [BetaToolBash20241022AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolBash20250124SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolBash20250124()
            {
                AllowedCallers = [BetaToolBash20250124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCodeExecutionTool20250522SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaCodeExecutionTool20250522()
            {
                AllowedCallers = [AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCodeExecutionTool20250825SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaCodeExecutionTool20250825()
            {
                AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolComputerUse20241022SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolComputerUse20241022()
            {
                DisplayHeightPx = 1,
                DisplayWidthPx = 1,
                AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMemoryTool20250818SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaMemoryTool20250818()
            {
                AllowedCallers = [BetaMemoryTool20250818AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolComputerUse20250124SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolComputerUse20250124()
            {
                DisplayHeightPx = 1,
                DisplayWidthPx = 1,
                AllowedCallers = [BetaToolComputerUse20250124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20241022SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20241022()
            {
                AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolComputerUse20251124SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolComputerUse20251124()
            {
                DisplayHeightPx = 1,
                DisplayWidthPx = 1,
                AllowedCallers = [BetaToolComputerUse20251124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20250124SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20250124()
            {
                AllowedCallers = [BetaToolTextEditor20250124AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20250429SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20250429()
            {
                AllowedCallers = [BetaToolTextEditor20250429AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20250728SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolTextEditor20250728()
            {
                AllowedCallers = [BetaToolTextEditor20250728AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebSearchTool20250305SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaWebSearchTool20250305()
            {
                AllowedCallers = [BetaWebSearchTool20250305AllowedCaller.Direct],
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchTool20250910SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaWebFetchTool20250910()
            {
                AllowedCallers = [BetaWebFetchTool20250910AllowedCaller.Direct],
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                DeferLoading = true,
                MaxContentTokens = 1,
                MaxUses = 1,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolSearchToolBm25_20251119SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolSearchToolBm25_20251119()
            {
                Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
                AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolSearchToolRegex20251119SerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaToolSearchToolRegex20251119()
            {
                Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
                AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMCPToolsetSerializationRoundtripWorks()
    {
        Tool value = new(
            new BetaMCPToolset()
            {
                MCPServerName = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Configs = new Dictionary<string, BetaMCPToolConfig>()
                {
                    {
                        "foo",
                        new() { DeferLoading = true, Enabled = true }
                    },
                },
                DefaultConfig = new() { DeferLoading = true, Enabled = true },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Tool>(element);

        Assert.Equal(value, deserialized);
    }
}
