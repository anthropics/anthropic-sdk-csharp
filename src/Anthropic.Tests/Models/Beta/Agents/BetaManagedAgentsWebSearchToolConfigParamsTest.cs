using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebSearchToolConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
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

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        bool expectedEnabled = true;
        BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );
        ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType> expectedType =
            BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch;
        BetaManagedAgentsUserLocation expectedUserLocation = new()
        {
            City = "x",
            Country = "country",
            Region = "x",
            Timezone = "x",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
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
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUserLocation, model.UserLocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        bool expectedEnabled = true;
        BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );
        ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType> expectedType =
            BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch;
        BetaManagedAgentsUserLocation expectedUserLocation = new()
        {
            City = "x",
            Country = "country",
            Region = "x",
            Timezone = "x",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
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
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUserLocation, deserialized.UserLocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            Type = null,
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
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
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            Type = BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch,
        };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.PermissionPolicy);
        Assert.False(model.RawData.ContainsKey("permission_policy"));
        Assert.Null(model.UserLocation);
        Assert.False(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            Type = BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            Type = BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch,

            Enabled = null,
            PermissionPolicy = null,
            UserLocation = null,
        };

        Assert.Null(model.Enabled);
        Assert.True(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.PermissionPolicy);
        Assert.True(model.RawData.ContainsKey("permission_policy"));
        Assert.Null(model.UserLocation);
        Assert.True(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            Type = BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch,

            Enabled = null,
            PermissionPolicy = null,
            UserLocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWebSearchToolConfigParams
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

        BetaManagedAgentsWebSearchToolConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy(BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk);
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy(BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsWebSearchToolConfigParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch)]
    public void Validation_Works(BetaManagedAgentsWebSearchToolConfigParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWebSearchToolConfigParamsType.WebSearch)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsWebSearchToolConfigParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebSearchToolConfigParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
