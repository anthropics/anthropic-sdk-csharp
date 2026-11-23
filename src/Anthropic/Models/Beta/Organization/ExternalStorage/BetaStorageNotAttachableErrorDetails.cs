using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// This External Storage can't be attached to the setting named in `field`. The error's
/// `message` says why.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaStorageNotAttachableErrorDetails,
        BetaStorageNotAttachableErrorDetailsFromRaw
    >)
)]
public sealed record class BetaStorageNotAttachableErrorDetails : JsonModel
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
    /// The request field at fault.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("storage_not_attachable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Field;
    }

    public BetaStorageNotAttachableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_not_attachable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageNotAttachableErrorDetails(
        BetaStorageNotAttachableErrorDetails betaStorageNotAttachableErrorDetails
    )
        : base(betaStorageNotAttachableErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageNotAttachableErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_not_attachable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageNotAttachableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageNotAttachableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageNotAttachableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaStorageNotAttachableErrorDetails(string field)
        : this()
    {
        this.Field = field;
    }
}

class BetaStorageNotAttachableErrorDetailsFromRaw
    : IFromRawJson<BetaStorageNotAttachableErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageNotAttachableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageNotAttachableErrorDetails.FromRawUnchecked(rawData);
}
