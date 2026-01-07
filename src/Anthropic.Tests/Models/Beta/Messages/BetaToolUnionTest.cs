using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolUnionTest : TestBase
{
    [Fact]
    public void BetaToolValidationWorks()
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
                CacheControl = new() { Ttl = Ttl.Ttl5m },
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
    public void Bash20241022ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolBash20241022()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void Bash20250124ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolBash20250124()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20250522ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaCodeExecutionTool20250522()
            {
                AllowedCallers = [AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20250825ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaCodeExecutionTool20250825()
            {
                AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void ComputerUse20241022ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolComputerUse20241022()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void MemoryTool20250818ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaMemoryTool20250818()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void ComputerUse20250124ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolComputerUse20250124()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextEditor20241022ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20241022()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void ComputerUse20251124ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolComputerUse20251124()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextEditor20250124ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20250124()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextEditor20250429ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20250429()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextEditor20250728ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20250728()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20250305ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaWebSearchTool20250305()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void WebFetchTool20250910ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaWebFetchTool20250910()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void SearchToolBm25_20251119ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolSearchToolBm25_20251119()
            {
                Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
                AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SearchToolRegex20251119ValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaToolSearchToolRegex20251119()
            {
                Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
                AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void McpToolsetValidationWorks()
    {
        BetaToolUnion value = new(
            new BetaMcpToolset()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolSerializationRoundtripWorks()
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
                CacheControl = new() { Ttl = Ttl.Ttl5m },
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
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Bash20241022SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolBash20241022()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Bash20250124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolBash20250124()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20250522SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaCodeExecutionTool20250522()
            {
                AllowedCallers = [AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20250825SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaCodeExecutionTool20250825()
            {
                AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerUse20241022SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolComputerUse20241022()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryTool20250818SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaMemoryTool20250818()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerUse20250124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolComputerUse20250124()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20241022SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20241022()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerUse20251124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolComputerUse20251124()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250124SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20250124()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250429SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20250429()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250728SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolTextEditor20250728()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20250305SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaWebSearchTool20250305()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20250910SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaWebFetchTool20250910()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchToolBm25_20251119SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolSearchToolBm25_20251119()
            {
                Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
                AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchToolRegex20251119SerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaToolSearchToolRegex20251119()
            {
                Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
                AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                DeferLoading = true,
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpToolsetSerializationRoundtripWorks()
    {
        BetaToolUnion value = new(
            new BetaMcpToolset()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolUnion>(element);

        Assert.Equal(value, deserialized);
    }
}
