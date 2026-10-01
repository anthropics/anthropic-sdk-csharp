using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaPluginContentScanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginContentScan
        {
            Assessment = Assessment.Warn,
            Reason = "credential-exposure",
            Status = Status.Completed,
        };

        ApiEnum<string, Assessment> expectedAssessment = Assessment.Warn;
        string expectedReason = "credential-exposure";
        ApiEnum<string, Status> expectedStatus = Status.Completed;

        Assert.Equal(expectedAssessment, model.Assessment);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginContentScan
        {
            Assessment = Assessment.Warn,
            Reason = "credential-exposure",
            Status = Status.Completed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginContentScan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginContentScan
        {
            Assessment = Assessment.Warn,
            Reason = "credential-exposure",
            Status = Status.Completed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginContentScan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Assessment> expectedAssessment = Assessment.Warn;
        string expectedReason = "credential-exposure";
        ApiEnum<string, Status> expectedStatus = Status.Completed;

        Assert.Equal(expectedAssessment, deserialized.Assessment);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginContentScan
        {
            Assessment = Assessment.Warn,
            Reason = "credential-exposure",
            Status = Status.Completed,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginContentScan
        {
            Assessment = Assessment.Warn,
            Reason = "credential-exposure",
            Status = Status.Completed,
        };

        BetaPluginContentScan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AssessmentTest : TestBase
{
    [Theory]
    [InlineData(Assessment.Fail)]
    [InlineData(Assessment.Pass)]
    [InlineData(Assessment.Unknown)]
    [InlineData(Assessment.Warn)]
    public void Validation_Works(Assessment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assessment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assessment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Assessment.Fail)]
    [InlineData(Assessment.Pass)]
    [InlineData(Assessment.Unknown)]
    [InlineData(Assessment.Warn)]
    public void SerializationRoundtrip_Works(Assessment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assessment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assessment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assessment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assessment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Errored)]
    [InlineData(Status.Processing)]
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
    [InlineData(Status.Completed)]
    [InlineData(Status.Errored)]
    [InlineData(Status.Processing)]
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
