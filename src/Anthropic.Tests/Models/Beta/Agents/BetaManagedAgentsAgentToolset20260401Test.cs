using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = Name.Bash,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };

        List<BetaManagedAgentsAgentToolConfig> expectedConfigs =
        [
            new()
            {
                Enabled = true,
                Name = Name.Bash,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        ];
        BetaManagedAgentsAgentToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type> expectedType =
            BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401;

        Assert.Equal(expectedConfigs.Count, model.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], model.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, model.DefaultConfig);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = Name.Bash,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = Name.Bash,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsAgentToolConfig> expectedConfigs =
        [
            new()
            {
                Enabled = true,
                Name = Name.Bash,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        ];
        BetaManagedAgentsAgentToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type> expectedType =
            BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401;

        Assert.Equal(expectedConfigs.Count, deserialized.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], deserialized.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, deserialized.DefaultConfig);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = Name.Bash,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = Name.Bash,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };

        BetaManagedAgentsAgentToolset20260401 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentToolset20260401TypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401)]
    public void Validation_Works(BetaManagedAgentsAgentToolset20260401Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentToolset20260401Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
