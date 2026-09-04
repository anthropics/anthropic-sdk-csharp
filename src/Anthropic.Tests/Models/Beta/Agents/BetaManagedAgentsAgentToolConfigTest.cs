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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        value.Validate();
    }

    [Fact]
    public void EditValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsEditToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        value.Validate();
    }

    [Fact]
    public void ReadValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsReadToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        value.Validate();
    }

    [Fact]
    public void WriteValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWriteToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        value.Validate();
    }

    [Fact]
    public void GlobValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGlobToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        value.Validate();
    }

    [Fact]
    public void GrepValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsGrepToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchValidationWorks()
    {
        BetaManagedAgentsAgentToolConfig value = new BetaManagedAgentsWebFetchToolConfig()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentToolConfig value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "enabled": true,
                  "name": "bash",
                  "type": "bash"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("bash");
        JsonElement expectedType = JsonSerializer.SerializeToElement("bash");

        Assert.Equal(expectedEnabled, value.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, value.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsAgentToolConfig emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Enabled);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

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
