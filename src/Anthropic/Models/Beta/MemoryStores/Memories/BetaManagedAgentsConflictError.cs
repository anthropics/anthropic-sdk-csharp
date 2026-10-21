using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsConflictError,
        BetaManagedAgentsConflictErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsConflictError : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("conflict_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Message;
    }

    public BetaManagedAgentsConflictError()
    {
        this.Type = JsonSerializer.SerializeToElement("conflict_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsConflictError(
        BetaManagedAgentsConflictError betaManagedAgentsConflictError
    )
        : base(betaManagedAgentsConflictError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsConflictError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("conflict_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsConflictError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsConflictErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsConflictError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsConflictErrorFromRaw : IFromRawJson<BetaManagedAgentsConflictError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsConflictError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsConflictError.FromRawUnchecked(rawData);
}
