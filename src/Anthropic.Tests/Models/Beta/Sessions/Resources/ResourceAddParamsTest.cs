using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Resources = Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class ResourceAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Resources::ResourceAddParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
            MountPath = "/uploads/receipt.pdf",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        ApiEnum<string, Resources::Type> expectedType = Resources::Type.File;
        string expectedMountPath = "/uploads/receipt.pdf";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedMountPath, parameters.MountPath);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Resources::ResourceAddParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
            MountPath = "/uploads/receipt.pdf",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Resources::ResourceAddParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
            MountPath = "/uploads/receipt.pdf",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Resources::ResourceAddParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.MountPath);
        Assert.False(parameters.RawBodyData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Resources::ResourceAddParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            MountPath = null,
        };

        Assert.Null(parameters.MountPath);
        Assert.True(parameters.RawBodyData.ContainsKey("mount_path"));
    }

    [Fact]
    public void Url_Works()
    {
        Resources::ResourceAddParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/sessions/sesn_011CZkZAtmR3yMPDzynEDxu7/resources?beta=true"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Resources::ResourceAddParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Resources::ResourceAddParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Resources::Type.File,
            MountPath = "/uploads/receipt.pdf",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Resources::ResourceAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Resources::Type.File)]
    public void Validation_Works(Resources::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Resources::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Resources::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Resources::Type.File)]
    public void SerializationRoundtrip_Works(Resources::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Resources::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Resources::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Resources::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Resources::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
