using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request came from a Claude sandbox with restricted network access, which
/// is not allowed to make this change. Send it from outside the sandbox, or from
/// a sandbox with unrestricted network access.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SandboxEgressRestrictedErrorDetails,
        SandboxEgressRestrictedErrorDetailsFromRaw
    >)
)]
public sealed record class SandboxEgressRestrictedErrorDetails : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("sandbox_egress_restricted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public SandboxEgressRestrictedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("sandbox_egress_restricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SandboxEgressRestrictedErrorDetails(
        SandboxEgressRestrictedErrorDetails sandboxEgressRestrictedErrorDetails
    )
        : base(sandboxEgressRestrictedErrorDetails) { }
#pragma warning restore CS8618

    public SandboxEgressRestrictedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("sandbox_egress_restricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SandboxEgressRestrictedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SandboxEgressRestrictedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static SandboxEgressRestrictedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SandboxEgressRestrictedErrorDetailsFromRaw : IFromRawJson<SandboxEgressRestrictedErrorDetails>
{
    /// <inheritdoc/>
    public SandboxEgressRestrictedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SandboxEgressRestrictedErrorDetails.FromRawUnchecked(rawData);
}
