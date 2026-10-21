using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchToolConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("web_fetch");
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch");
        BetaManagedAgentsWebFetchUrlSources expectedUrlSources = new()
        {
            ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
        };
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        int expectedMaxContentTokens = 0;

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrlSources, model.UrlSources);
        Assert.NotNull(model.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, model.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], model.AllowedDomains[i]);
        }
        Assert.NotNull(model.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, model.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], model.BlockedDomains[i]);
        }
        Assert.Equal(expectedMaxContentTokens, model.MaxContentTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchToolConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchToolConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("web_fetch");
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch");
        BetaManagedAgentsWebFetchUrlSources expectedUrlSources = new()
        {
            ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
        };
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        int expectedMaxContentTokens = 0;

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrlSources, deserialized.UrlSources);
        Assert.NotNull(deserialized.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, deserialized.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], deserialized.AllowedDomains[i]);
        }
        Assert.NotNull(deserialized.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, deserialized.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], deserialized.BlockedDomains[i]);
        }
        Assert.Equal(expectedMaxContentTokens, deserialized.MaxContentTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UrlSources = new()
            {
                ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
            },
            MaxContentTokens = 0,
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UrlSources = new()
            {
                ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
            },
            MaxContentTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UrlSources = new()
            {
                ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
            },
            MaxContentTokens = 0,

            // Null should be interpreted as omitted for these properties
            AllowedDomains = null,
            BlockedDomains = null,
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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
        } with
        {
            // Null should be interpreted as omitted for these properties
            AllowedDomains = null,
            BlockedDomains = null,
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UrlSources = new()
            {
                ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
                UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
            },
            MaxContentTokens = 0,

            // Null should be interpreted as omitted for these properties
            AllowedDomains = null,
            BlockedDomains = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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
        };

        Assert.Null(model.MaxContentTokens);
        Assert.False(model.RawData.ContainsKey("max_content_tokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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

            MaxContentTokens = null,
        };

        Assert.Null(model.MaxContentTokens);
        Assert.True(model.RawData.ContainsKey("max_content_tokens"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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

            MaxContentTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWebFetchToolConfig
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

        BetaManagedAgentsWebFetchToolConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsWebFetchToolConfigPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAutoValidationWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebFetchToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebFetchToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebFetchToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowTypeWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        Assert.Equal(
            BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.AlwaysAllow,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskTypeWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        Assert.Equal(
            BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.AlwaysAsk,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAutoTypeWorks()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        Assert.Equal(
            BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.Auto,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWebFetchToolConfigPermissionPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsWebFetchToolConfigPermissionPolicyType> expectedType =
            BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsWebFetchToolConfigPermissionPolicy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsWebFetchToolConfigPermissionPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.Auto)]
    public void Validation_Works(BetaManagedAgentsWebFetchToolConfigPermissionPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebFetchToolConfigPermissionPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsWebFetchToolConfigPermissionPolicyType.Auto)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsWebFetchToolConfigPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebFetchToolConfigPermissionPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
