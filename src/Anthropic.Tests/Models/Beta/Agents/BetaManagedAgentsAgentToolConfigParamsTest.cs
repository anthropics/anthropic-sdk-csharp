using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName> expectedName =
            BetaManagedAgentsAgentToolConfigParamsName.Bash;
        bool expectedEnabled = true;
        BetaManagedAgentsAgentToolConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName> expectedName =
            BetaManagedAgentsAgentToolConfigParamsName.Bash;
        bool expectedEnabled = true;
        BetaManagedAgentsAgentToolConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
        };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.PermissionPolicy);
        Assert.False(model.RawData.ContainsKey("permission_policy"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,

            Enabled = null,
            PermissionPolicy = null,
        };

        Assert.Null(model.Enabled);
        Assert.True(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.PermissionPolicy);
        Assert.True(model.RawData.ContainsKey("permission_policy"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,

            Enabled = null,
            PermissionPolicy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolConfigParams
        {
            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        BetaManagedAgentsAgentToolConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentToolConfigParamsNameTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Bash)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Edit)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Read)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Write)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Glob)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Grep)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.WebFetch)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.WebSearch)]
    public void Validation_Works(BetaManagedAgentsAgentToolConfigParamsName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Bash)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Edit)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Read)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Write)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Glob)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.Grep)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.WebFetch)]
    [InlineData(BetaManagedAgentsAgentToolConfigParamsName.WebSearch)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentToolConfigParamsName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolConfigParamsName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsAgentToolConfigParamsPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsAgentToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy(BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk);
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy(BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
