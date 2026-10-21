using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolConfigTest : TestBase
{
    [Fact]
    public void BashValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsBashToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        value.Validate();
    }

    [Fact]
    public void EditValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsEditToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        value.Validate();
    }

    [Fact]
    public void ReadValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsReadToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        value.Validate();
    }

    [Fact]
    public void WriteValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWriteToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        value.Validate();
    }

    [Fact]
    public void GlobValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGlobToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        value.Validate();
    }

    [Fact]
    public void GrepValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGrepToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWebFetchToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UrlSources = new()
            {
                ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
            },
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            MaxContentTokens = 0,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWebSearchToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            UserLocation = new()
            {
                City = "x",
                Country = "country",
                Region = "x",
                Timezone = "x",
            },
        };
        value.Validate();
    }

    [Fact]
    public void BashSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsBashToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EditSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsEditToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsReadToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WriteSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWriteToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GlobSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGlobToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GrepSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGrepToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWebFetchToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UrlSources = new()
            {
                ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
            },
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            MaxContentTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWebSearchToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            UserLocation = new()
            {
                City = "x",
                Country = "country",
                Region = "x",
                Timezone = "x",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsBashToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.Bash, value.Type.Value());
    }

    [Fact]
    public void EditTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsEditToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.Edit, value.Type.Value());
    }

    [Fact]
    public void ReadTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsReadToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.Read, value.Type.Value());
    }

    [Fact]
    public void WriteTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWriteToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.Write, value.Type.Value());
    }

    [Fact]
    public void GlobTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGlobToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.Glob, value.Type.Value());
    }

    [Fact]
    public void GrepTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGrepToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.Grep, value.Type.Value());
    }

    [Fact]
    public void WebFetchTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWebFetchToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UrlSources = new()
            {
                ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
            },
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            MaxContentTokens = 0,
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.WebFetch, value.Type.Value());
    }

    [Fact]
    public void WebSearchTypeWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWebSearchToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            UserLocation = new()
            {
                City = "x",
                Country = "country",
                Region = "x",
                Timezone = "x",
            },
        };
        Assert.Equal(BetaManagedAgentsAgentToolConfigType.WebSearch, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentToolConfig value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "enabled": true,
                  "name": "bash",
                  "type": "bash",
                  "allowed_domains": [
                    "string"
                  ],
                  "blocked_domains": [
                    "string"
                  ]
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("bash");
        ApiEnum<string, BetaManagedAgentsAgentToolConfigType> expectedType =
            BetaManagedAgentsAgentToolConfigType.Bash;
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];

        Assert.Equal(expectedEnabled, value.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, value.Name));
        Assert.Equal(expectedType, value.Type);
        Assert.NotNull(value.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, value.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], value.AllowedDomains[i]);
        }
        Assert.NotNull(value.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, value.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], value.BlockedDomains[i]);
        }

        BetaManagedAgentsAgentToolConfig emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Enabled);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.AllowedDomains);
        Assert.Null(emptyValue.BlockedDomains);

        BetaManagedAgentsAgentToolConfig mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "enabled": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Enabled);
    }
}

public class BetaManagedAgentsAgentToolConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Bash)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Edit)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Read)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Write)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Glob)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Grep)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.WebFetch)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.WebSearch)]
    public void Validation_Works(BetaManagedAgentsAgentToolConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Bash)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Edit)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Read)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Write)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Glob)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.Grep)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.WebFetch)]
    [InlineData(BetaManagedAgentsAgentToolConfigType.WebSearch)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentToolConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
