using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The request breaks the organization's Workspace Policy. The message says which
/// rule it broke; an organization admin can see and change the policy in the Console.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePolicyViolationErrorDetails,
        WorkspacePolicyViolationErrorDetailsFromRaw
    >)
)]
public sealed record class WorkspacePolicyViolationErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// The request field the broken rule applies to.
    /// </summary>
    public required ApiEnum<string, WorkspacePolicyField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WorkspacePolicyField>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("workspace_policy_violation")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Field.Validate();
    }

    public WorkspacePolicyViolationErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_policy_violation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePolicyViolationErrorDetails(
        WorkspacePolicyViolationErrorDetails workspacePolicyViolationErrorDetails
    )
        : base(workspacePolicyViolationErrorDetails) { }
#pragma warning restore CS8618

    public WorkspacePolicyViolationErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_policy_violation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePolicyViolationErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePolicyViolationErrorDetailsFromRaw.FromRawUnchecked"/>
    public static WorkspacePolicyViolationErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorkspacePolicyViolationErrorDetails(ApiEnum<string, WorkspacePolicyField> field)
        : this()
    {
        this.Field = field;
    }
}

class WorkspacePolicyViolationErrorDetailsFromRaw
    : IFromRawJson<WorkspacePolicyViolationErrorDetails>
{
    /// <inheritdoc/>
    public WorkspacePolicyViolationErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePolicyViolationErrorDetails.FromRawUnchecked(rawData);
}
