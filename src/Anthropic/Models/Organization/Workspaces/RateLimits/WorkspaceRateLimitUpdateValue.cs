using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Workspaces.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<WorkspaceRateLimitUpdateValue, WorkspaceRateLimitUpdateValueFromRaw>)
)]
public sealed record class WorkspaceRateLimitUpdateValue : JsonModel
{
    /// <summary>
    /// Rate limiter type.
    /// </summary>
    public required ApiEnum<string, WorkspaceRateLimitType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WorkspaceRateLimitType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// New limit value. Set to null to clear the workspace override and fall back
    /// to the organization limit.
    /// </summary>
    public required long? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public WorkspaceRateLimitUpdateValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceRateLimitUpdateValue(
        WorkspaceRateLimitUpdateValue workspaceRateLimitUpdateValue
    )
        : base(workspaceRateLimitUpdateValue) { }
#pragma warning restore CS8618

    public WorkspaceRateLimitUpdateValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceRateLimitUpdateValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceRateLimitUpdateValueFromRaw.FromRawUnchecked"/>
    public static WorkspaceRateLimitUpdateValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceRateLimitUpdateValueFromRaw : IFromRawJson<WorkspaceRateLimitUpdateValue>
{
    /// <inheritdoc/>
    public WorkspaceRateLimitUpdateValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceRateLimitUpdateValue.FromRawUnchecked(rawData);
}
