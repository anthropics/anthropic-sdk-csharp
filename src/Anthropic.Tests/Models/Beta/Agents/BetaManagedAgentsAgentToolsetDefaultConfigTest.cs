using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolsetDefaultConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolsetDefaultConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        bool expectedEnabled = true;
        PermissionPolicy expectedPermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
        );

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolsetDefaultConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolsetDefaultConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolsetDefaultConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolsetDefaultConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        PermissionPolicy expectedPermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
        );

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolsetDefaultConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolsetDefaultConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };

        BetaManagedAgentsAgentToolsetDefaultConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        PermissionPolicy value = new BetaManagedAgentsAlwaysAllowPolicy(
            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        PermissionPolicy value = new BetaManagedAgentsAlwaysAskPolicy(
            BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        PermissionPolicy value = new BetaManagedAgentsAlwaysAllowPolicy(
            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionPolicy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        PermissionPolicy value = new BetaManagedAgentsAlwaysAskPolicy(
            BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionPolicy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
