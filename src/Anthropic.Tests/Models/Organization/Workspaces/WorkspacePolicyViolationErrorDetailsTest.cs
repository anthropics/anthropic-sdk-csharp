using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

public class WorkspacePolicyViolationErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspacePolicyViolationErrorDetails
        {
            Field = WorkspacePolicyField.ExternalKeyID,
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "workspace_policy_violation"
        );
        ApiEnum<string, WorkspacePolicyField> expectedField = WorkspacePolicyField.ExternalKeyID;

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspacePolicyViolationErrorDetails
        {
            Field = WorkspacePolicyField.ExternalKeyID,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePolicyViolationErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspacePolicyViolationErrorDetails
        {
            Field = WorkspacePolicyField.ExternalKeyID,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePolicyViolationErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "workspace_policy_violation"
        );
        ApiEnum<string, WorkspacePolicyField> expectedField = WorkspacePolicyField.ExternalKeyID;

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspacePolicyViolationErrorDetails
        {
            Field = WorkspacePolicyField.ExternalKeyID,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspacePolicyViolationErrorDetails
        {
            Field = WorkspacePolicyField.ExternalKeyID,
        };

        WorkspacePolicyViolationErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
