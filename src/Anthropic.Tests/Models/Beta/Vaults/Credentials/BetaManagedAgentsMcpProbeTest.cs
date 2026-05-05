using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpProbeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpProbe
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Method = "method",
        };

        BetaManagedAgentsRefreshHttpResponse expectedHttpResponse = new()
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };
        string expectedMethod = "method";

        Assert.Equal(expectedHttpResponse, model.HttpResponse);
        Assert.Equal(expectedMethod, model.Method);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpProbe
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Method = "method",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpProbe>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpProbe
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Method = "method",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpProbe>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsRefreshHttpResponse expectedHttpResponse = new()
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };
        string expectedMethod = "method";

        Assert.Equal(expectedHttpResponse, deserialized.HttpResponse);
        Assert.Equal(expectedMethod, deserialized.Method);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpProbe
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Method = "method",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpProbe
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Method = "method",
        };

        BetaManagedAgentsMcpProbe copied = new(model);

        Assert.Equal(model, copied);
    }
}
