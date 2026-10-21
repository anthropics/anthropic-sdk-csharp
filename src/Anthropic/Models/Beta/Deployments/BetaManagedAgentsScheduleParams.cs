using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A recurring schedule. Discriminated union — only cron is supported currently.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsScheduleParams,
        BetaManagedAgentsScheduleParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsScheduleParams : JsonModel
{
    /// <summary>
    /// 5-field POSIX cron expression: minute hour day-of-month month day-of-week
    /// (e.g., "0 9 * * 1-5" for weekdays at 9am). Day-of-week is 0-7 where 0 and
    /// 7 both mean Sunday. Extended cron syntax - seconds or year fields, and the
    /// special characters L, W, #, and ? - is not supported, nor are predefined shortcuts (@daily).
    /// </summary>
    public required string Expression
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expression");
        }
        init { this._rawData.Set("expression", value); }
    }

    /// <summary>
    /// Required. IANA timezone identifier (e.g., "America/Los_Angeles", "UTC"). Validated
    /// against the IANA timezone database.
    /// </summary>
    public required string Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Expression;
        _ = this.Timezone;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("cron")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsScheduleParams()
    {
        this.Type = JsonSerializer.SerializeToElement("cron");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsScheduleParams(
        BetaManagedAgentsScheduleParams betaManagedAgentsScheduleParams
    )
        : base(betaManagedAgentsScheduleParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsScheduleParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("cron");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsScheduleParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsScheduleParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsScheduleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsScheduleParamsFromRaw : IFromRawJson<BetaManagedAgentsScheduleParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsScheduleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsScheduleParams.FromRawUnchecked(rawData);
}
