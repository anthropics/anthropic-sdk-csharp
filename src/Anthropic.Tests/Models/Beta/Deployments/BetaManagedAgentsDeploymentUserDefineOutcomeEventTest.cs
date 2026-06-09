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
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
            MaxIterations = 0,
        };

        string expectedDescription = "description";
        Rubric expectedRubric = new Events::BetaManagedAgentsFileRubric()
        {
            FileID = "file_id",
            Type = Events::BetaManagedAgentsFileRubricType.File,
        };
        ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType> expectedType =
            BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome;
        int expectedMaxIterations = 0;

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedRubric, model.Rubric);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedMaxIterations, model.MaxIterations);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
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
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
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
        Rubric expectedRubric = new Events::BetaManagedAgentsFileRubric()
        {
            FileID = "file_id",
            Type = Events::BetaManagedAgentsFileRubricType.File,
        };
        ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType> expectedType =
            BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome;
        int expectedMaxIterations = 0;

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedRubric, deserialized.Rubric);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedMaxIterations, deserialized.MaxIterations);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
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
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
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
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserDefineOutcomeEvent
        {
            Description = "description",
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,

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
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,

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
            Rubric = new Events::BetaManagedAgentsFileRubric()
            {
                FileID = "file_id",
                Type = Events::BetaManagedAgentsFileRubricType.File,
            },
            Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
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
        Rubric value = new Events::BetaManagedAgentsFileRubric()
        {
            FileID = "file_id",
            Type = Events::BetaManagedAgentsFileRubricType.File,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextValidationWorks()
    {
        Rubric value = new Events::BetaManagedAgentsTextRubric()
        {
            Content = "content",
            Type = Events::BetaManagedAgentsTextRubricType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileSerializationRoundtripWorks()
    {
        Rubric value = new Events::BetaManagedAgentsFileRubric()
        {
            FileID = "file_id",
            Type = Events::BetaManagedAgentsFileRubricType.File,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextSerializationRoundtripWorks()
    {
        Rubric value = new Events::BetaManagedAgentsTextRubric()
        {
            Content = "content",
            Type = Events::BetaManagedAgentsTextRubricType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsDeploymentUserDefineOutcomeEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome)]
    public void Validation_Works(BetaManagedAgentsDeploymentUserDefineOutcomeEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsDeploymentUserDefineOutcomeEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
