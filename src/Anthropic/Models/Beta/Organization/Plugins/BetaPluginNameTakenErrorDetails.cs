using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// The marketplace already holds this name. `plugin_id` is the Plugin that holds
/// it, and can be absent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaPluginNameTakenErrorDetails,
        BetaPluginNameTakenErrorDetailsFromRaw
    >)
)]
public sealed record class BetaPluginNameTakenErrorDetails : JsonModel
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

    public string? PluginID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("plugin_id");
        }
        init { this._rawData.Set("plugin_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("plugin_name_taken")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.PluginID;
    }

    public BetaPluginNameTakenErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("plugin_name_taken");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginNameTakenErrorDetails(
        BetaPluginNameTakenErrorDetails betaPluginNameTakenErrorDetails
    )
        : base(betaPluginNameTakenErrorDetails) { }
#pragma warning restore CS8618

    public BetaPluginNameTakenErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("plugin_name_taken");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginNameTakenErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginNameTakenErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaPluginNameTakenErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginNameTakenErrorDetailsFromRaw : IFromRawJson<BetaPluginNameTakenErrorDetails>
{
    /// <inheritdoc/>
    public BetaPluginNameTakenErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginNameTakenErrorDetails.FromRawUnchecked(rawData);
}
