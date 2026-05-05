using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsRefreshHttpResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRefreshHttpResponse
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };

        string expectedBody = "body";
        bool expectedBodyTruncated = true;
        string expectedContentType = "content_type";
        int expectedStatusCode = 0;

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedBodyTruncated, model.BodyTruncated);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedStatusCode, model.StatusCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRefreshHttpResponse
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRefreshHttpResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRefreshHttpResponse
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRefreshHttpResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBody = "body";
        bool expectedBodyTruncated = true;
        string expectedContentType = "content_type";
        int expectedStatusCode = 0;

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedBodyTruncated, deserialized.BodyTruncated);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRefreshHttpResponse
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRefreshHttpResponse
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };

        BetaManagedAgentsRefreshHttpResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
