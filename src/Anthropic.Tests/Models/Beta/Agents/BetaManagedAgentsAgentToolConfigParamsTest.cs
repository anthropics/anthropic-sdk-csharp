using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolConfigParamsTest : TestBase
{
    [Fact]
    public void BashValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsBashToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsBashToolConfigParamsType.Bash,
        };
        value.Validate();
    }

    [Fact]
    public void EditValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsEditToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };
        value.Validate();
    }

    [Fact]
    public void ReadValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsReadToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsReadToolConfigParamsType.Read,
        };
        value.Validate();
    }

    [Fact]
    public void WriteValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsWriteToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsWriteToolConfigParamsType.Write,
        };
        value.Validate();
    }

    [Fact]
    public void GlobValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsGlobToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsGlobToolConfigParamsType.Glob,
        };
        value.Validate();
    }

    [Fact]
    public void GrepValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsGrepToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsGrepToolConfigParamsType.Grep,
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value =
            new BetaManagedAgentsWebFetchToolConfigParams()
            {
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                Enabled = true,
                MaxContentTokens = 0,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
                Type = BetaManagedAgentsWebFetchToolConfigParamsType.WebFetch,
                UrlSources = new()
                {
                    ClientToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
                    ServerToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
                    UserInput = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
                },
            };
        value.Validate();
    }

    [Fact]
    public void WebSearchValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value =
            new BetaManagedAgentsWebSearchToolConfigParams()
            {
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
                Type = BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch,
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
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsBashToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsBashToolConfigParamsType.Bash,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EditSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsEditToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsReadToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsReadToolConfigParamsType.Read,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WriteSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsWriteToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsWriteToolConfigParamsType.Write,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GlobSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsGlobToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsGlobToolConfigParamsType.Glob,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GrepSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value = new BetaManagedAgentsGrepToolConfigParams()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
            Type = BetaManagedAgentsGrepToolConfigParamsType.Grep,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value =
            new BetaManagedAgentsWebFetchToolConfigParams()
            {
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                Enabled = true,
                MaxContentTokens = 0,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
                Type = BetaManagedAgentsWebFetchToolConfigParamsType.WebFetch,
                UrlSources = new()
                {
                    ClientToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
                    ServerToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
                    UserInput = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParams value =
            new BetaManagedAgentsWebSearchToolConfigParams()
            {
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
                Type = BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch,
                UserLocation = new()
                {
                    City = "x",
                    Country = "country",
                    Region = "x",
                    Timezone = "x",
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentToolConfigParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "name": "bash",
                  "enabled": true,
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

        JsonElement expectedName = JsonSerializer.SerializeToElement("bash");
        bool expectedEnabled = true;
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedName, value.Name));
        Assert.Equal(expectedEnabled, value.Enabled);
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

        BetaManagedAgentsAgentToolConfigParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Name);
        Assert.Null(emptyValue.Enabled);
        Assert.Null(emptyValue.AllowedDomains);
        Assert.Null(emptyValue.BlockedDomains);

        BetaManagedAgentsAgentToolConfigParams mismatchedValue = new(
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

        Assert.Null(mismatchedValue.Enabled);
    }
}
