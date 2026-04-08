using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaLimitedNetworkParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaLimitedNetworkParams
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("limited");
        bool expectedAllowMcpServers = true;
        bool expectedAllowPackageManagers = true;
        List<string> expectedAllowedHosts = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAllowMcpServers, model.AllowMcpServers);
        Assert.Equal(expectedAllowPackageManagers, model.AllowPackageManagers);
        Assert.NotNull(model.AllowedHosts);
        Assert.Equal(expectedAllowedHosts.Count, model.AllowedHosts.Count);
        for (int i = 0; i < expectedAllowedHosts.Count; i++)
        {
            Assert.Equal(expectedAllowedHosts[i], model.AllowedHosts[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaLimitedNetworkParams
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaLimitedNetworkParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaLimitedNetworkParams
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaLimitedNetworkParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("limited");
        bool expectedAllowMcpServers = true;
        bool expectedAllowPackageManagers = true;
        List<string> expectedAllowedHosts = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedAllowMcpServers, deserialized.AllowMcpServers);
        Assert.Equal(expectedAllowPackageManagers, deserialized.AllowPackageManagers);
        Assert.NotNull(deserialized.AllowedHosts);
        Assert.Equal(expectedAllowedHosts.Count, deserialized.AllowedHosts.Count);
        for (int i = 0; i < expectedAllowedHosts.Count; i++)
        {
            Assert.Equal(expectedAllowedHosts[i], deserialized.AllowedHosts[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaLimitedNetworkParams
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaLimitedNetworkParams { };

        Assert.Null(model.AllowMcpServers);
        Assert.False(model.RawData.ContainsKey("allow_mcp_servers"));
        Assert.Null(model.AllowPackageManagers);
        Assert.False(model.RawData.ContainsKey("allow_package_managers"));
        Assert.Null(model.AllowedHosts);
        Assert.False(model.RawData.ContainsKey("allowed_hosts"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaLimitedNetworkParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaLimitedNetworkParams
        {
            AllowMcpServers = null,
            AllowPackageManagers = null,
            AllowedHosts = null,
        };

        Assert.Null(model.AllowMcpServers);
        Assert.True(model.RawData.ContainsKey("allow_mcp_servers"));
        Assert.Null(model.AllowPackageManagers);
        Assert.True(model.RawData.ContainsKey("allow_package_managers"));
        Assert.Null(model.AllowedHosts);
        Assert.True(model.RawData.ContainsKey("allowed_hosts"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaLimitedNetworkParams
        {
            AllowMcpServers = null,
            AllowPackageManagers = null,
            AllowedHosts = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaLimitedNetworkParams
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };

        BetaLimitedNetworkParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
