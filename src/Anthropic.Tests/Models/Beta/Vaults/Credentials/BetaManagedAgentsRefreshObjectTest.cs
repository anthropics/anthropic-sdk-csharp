using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsRefreshObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRefreshObject
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Status = Status.Succeeded,
        };

        BetaManagedAgentsRefreshHttpResponse expectedHttpResponse = new()
        {
            Body = "body",
            BodyTruncated = true,
            ContentType = "content_type",
            StatusCode = 0,
        };
        ApiEnum<string, Status> expectedStatus = Status.Succeeded;

        Assert.Equal(expectedHttpResponse, model.HttpResponse);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRefreshObject
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Status = Status.Succeeded,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRefreshObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRefreshObject
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Status = Status.Succeeded,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRefreshObject>(
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
        ApiEnum<string, Status> expectedStatus = Status.Succeeded;

        Assert.Equal(expectedHttpResponse, deserialized.HttpResponse);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRefreshObject
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Status = Status.Succeeded,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRefreshObject
        {
            HttpResponse = new()
            {
                Body = "body",
                BodyTruncated = true,
                ContentType = "content_type",
                StatusCode = 0,
            },
            Status = Status.Succeeded,
        };

        BetaManagedAgentsRefreshObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Succeeded)]
    [InlineData(Status.Failed)]
    [InlineData(Status.ConnectError)]
    [InlineData(Status.NoRefreshToken)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Succeeded)]
    [InlineData(Status.Failed)]
    [InlineData(Status.ConnectError)]
    [InlineData(Status.NoRefreshToken)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
