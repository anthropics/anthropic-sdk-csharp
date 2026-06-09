using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsWorkspaceArchivedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType> expectedType =
            BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkspaceArchivedRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkspaceArchivedRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType> expectedType =
            BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
        };

        BetaManagedAgentsWorkspaceArchivedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsWorkspaceArchivedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError)]
    public void Validation_Works(BetaManagedAgentsWorkspaceArchivedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsWorkspaceArchivedRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
