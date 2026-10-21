using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebSearchToolConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
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

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search");
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaManagedAgentsUserLocation expectedUserLocation = new()
        {
            City = "x",
            Country = "country",
            Region = "x",
            Timezone = "x",
        };

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
        Assert.Equal(expectedUserLocation, model.UserLocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search");
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaManagedAgentsUserLocation expectedUserLocation = new()
        {
            City = "x",
            Country = "country",
            Region = "x",
            Timezone = "x",
        };

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
        Assert.Equal(expectedUserLocation, deserialized.UserLocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UserLocation = new()
            {
                City = "x",
                Country = "country",
                Region = "x",
                Timezone = "x",
            },
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UserLocation = new()
            {
                City = "x",
                Country = "country",
                Region = "x",
                Timezone = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UserLocation = new()
            {
                City = "x",
                Country = "country",
                Region = "x",
                Timezone = "x",
            },

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
        var model = new BetaManagedAgentsWebSearchToolConfig
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
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            UserLocation = new()
            {
                City = "x",
                Country = "country",
                Region = "x",
                Timezone = "x",
            },

            // Null should be interpreted as omitted for these properties
            AllowedDomains = null,
            BlockedDomains = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
        };

        Assert.Null(model.UserLocation);
        Assert.False(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],

            UserLocation = null,
        };

        Assert.Null(model.UserLocation);
        Assert.True(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],

            UserLocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfig
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

        BetaManagedAgentsWebSearchToolConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsWebSearchToolConfigPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAutoValidationWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowTypeWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        Assert.Equal(
            BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.AlwaysAllow,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskTypeWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        Assert.Equal(
            BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.AlwaysAsk,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAutoTypeWorks()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        Assert.Equal(
            BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.Auto,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWebSearchToolConfigPermissionPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsWebSearchToolConfigPermissionPolicyType> expectedType =
            BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsWebSearchToolConfigPermissionPolicy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsWebSearchToolConfigPermissionPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.Auto)]
    public void Validation_Works(BetaManagedAgentsWebSearchToolConfigPermissionPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebSearchToolConfigPermissionPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsWebSearchToolConfigPermissionPolicyType.Auto)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsWebSearchToolConfigPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebSearchToolConfigPermissionPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
