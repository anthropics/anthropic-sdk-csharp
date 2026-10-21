using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentUserDefineOutcomeEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),
            MaxIterations = 0,
        };

        string expectedDescription = "description";
        Rubric expectedRubric = new Events::BetaManagedAgentsFileRubric("file_id");
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.define_outcome");
        int expectedMaxIterations = 0;

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedRubric, model.Rubric);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedMaxIterations, model.MaxIterations);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),
            MaxIterations = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentUserDefineOutcomeEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),
            MaxIterations = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentUserDefineOutcomeEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        Rubric expectedRubric = new Events::BetaManagedAgentsFileRubric("file_id");
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.define_outcome");
        int expectedMaxIterations = 0;

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedRubric, deserialized.Rubric);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedMaxIterations, deserialized.MaxIterations);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),
            MaxIterations = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),
        };

        Assert.Null(model.MaxIterations);
        Assert.False(model.RawData.ContainsKey("max_iterations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),

            MaxIterations = null,
        };

        Assert.Null(model.MaxIterations);
        Assert.True(model.RawData.ContainsKey("max_iterations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),

            MaxIterations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric("file_id"),
            MaxIterations = 0,
        };

        BetaManagedAgentsDeploymentUserDefineOutcomeEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RubricTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsFileValidationWorks()
    {
        Rubric value = new Events::BetaManagedAgentsFileRubric("file_id");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextValidationWorks()
    {
        Rubric value = new Events::BetaManagedAgentsTextRubric("content");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileSerializationRoundtripWorks()
    {
        Rubric value = new Events::BetaManagedAgentsFileRubric("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextSerializationRoundtripWorks()
    {
        Rubric value = new Events::BetaManagedAgentsTextRubric("content");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileTypeWorks()
    {
        Rubric value = new Events::BetaManagedAgentsFileRubric("file_id");
        Assert.Equal(RubricType.File, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsTextTypeWorks()
    {
        Rubric value = new Events::BetaManagedAgentsTextRubric("content");
        Assert.Equal(RubricType.Text, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Rubric value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "file"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, RubricType> expectedType = RubricType.File;

        Assert.Equal(expectedType, value.Type);

        Rubric emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class RubricTypeTest : TestBase
{
    [Theory]
    [InlineData(RubricType.File)]
    [InlineData(RubricType.Text)]
    public void Validation_Works(RubricType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RubricType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RubricType.File)]
    [InlineData(RubricType.Text)]
    public void SerializationRoundtrip_Works(RubricType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RubricType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
