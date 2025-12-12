using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolUnionTest : TestBase
{
    [Fact]
    public void beta_toolValidation_Works()
    {
        BetaToolUnion value = new(
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
    public void bash_20241022Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void bash_20250124Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void code_execution_tool_20250522Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void code_execution_tool_20250825Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void computer_use_20241022Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void memory_tool_20250818Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void computer_use_20250124Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void text_editor_20241022Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void computer_use_20251124Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void text_editor_20250124Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void text_editor_20250429Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void text_editor_20250728Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void web_search_tool_20250305Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void web_fetch_tool_20250910Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void search_tool_bm25_20251119Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void search_tool_regex_20251119Validation_Works()
    {
        BetaToolUnion value = new(
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
    public void mcp_toolsetValidation_Works()
    {
        BetaToolUnion value = new(
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
    public void beta_toolSerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void bash_20241022SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void bash_20250124SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void code_execution_tool_20250522SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
            new BetaCodeExecutionTool20250522()
            {
                AllowedCallers = [AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void code_execution_tool_20250825SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
            new BetaCodeExecutionTool20250825()
            {
                AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void computer_use_20241022SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void memory_tool_20250818SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void computer_use_20250124SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_20241022SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void computer_use_20251124SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_20250124SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_20250429SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_20250728SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_search_tool_20250305SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_fetch_tool_20250910SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void search_tool_bm25_20251119SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
            new BetaToolSearchToolBm25_20251119()
            {
                Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
                AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void search_tool_regex_20251119SerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
            new BetaToolSearchToolRegex20251119()
            {
                Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
                AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
                CacheControl = new() { TTL = TTL.TTL5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void mcp_toolsetSerializationRoundtrip_Works()
    {
        BetaToolUnion value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(json);

        Assert.Equal(value, deserialized);
    }
}
