using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// The error returned with HTTP status 409 when a request's precondition doesn't
/// hold for the memory's current state, such as `precondition` on an update or `expected_content_sha256`
/// on a delete.
///
/// <para>The error doesn't include the memory's current state. Retrieve the memory
/// to see its current content and `content_sha256` before you retry.</para>
///
/// <para>See the [memory guide](https://platform.claude.com/docs/en/managed-agents/memory#safe-content-edits-optimistic-concurrency)
/// to learn more about safe content edits with content hash preconditions.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryPreconditionFailedError,
        BetaManagedAgentsMemoryPreconditionFailedErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryPreconditionFailedError : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A human-readable explanation of why the precondition failed.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("message");
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("memory_precondition_failed_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Message;
    }

    public BetaManagedAgentsMemoryPreconditionFailedError()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_precondition_failed_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryPreconditionFailedError(
        BetaManagedAgentsMemoryPreconditionFailedError betaManagedAgentsMemoryPreconditionFailedError
    )
        : base(betaManagedAgentsMemoryPreconditionFailedError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryPreconditionFailedError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_precondition_failed_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryPreconditionFailedError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryPreconditionFailedErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryPreconditionFailedError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryPreconditionFailedErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMemoryPreconditionFailedError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryPreconditionFailedError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryPreconditionFailedError.FromRawUnchecked(rawData);
}
