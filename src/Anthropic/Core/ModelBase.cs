using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Files;
using Anthropic.Models.Messages.Batches;
using Batches = Anthropic.Models.Beta.Messages.Batches;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Messages::MediaType>(),
            new ApiEnumConverter<string, Messages::TTL>(),
            new ApiEnumConverter<string, Messages::Role>(),
            new ApiEnumConverter<string, Messages::Model>(),
            new ApiEnumConverter<string, Messages::StopReason>(),
            new ApiEnumConverter<string, Messages::Type>(),
            new ApiEnumConverter<string, Messages::UsageServiceTier>(),
            new ApiEnumConverter<string, Messages::ErrorCode>(),
            new ApiEnumConverter<string, Messages::WebSearchToolResultErrorErrorCode>(),
            new ApiEnumConverter<string, Messages::ServiceTier>(),
            new ApiEnumConverter<string, ProcessingStatus>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, AnthropicBeta>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.MediaType>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.ErrorCode>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaBashCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.TTL>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.AllowedCallerModel
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller1>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.Role>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.Effort>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.Name>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaServerToolUseBlockParamName
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.Type>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaSkillParamsType
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.BetaStopReason>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultErrorErrorCode
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.FileType>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaTextEditorCodeExecutionViewResultBlockParamFileType
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller2>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.BetaToolType>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller3>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller4>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller5>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller6>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller7>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaToolSearchToolBm25_20251119Type
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller8>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaToolSearchToolRegex20251119Type
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller9>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaToolSearchToolResultErrorErrorCode
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaToolSearchToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller10>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller11>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller12>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller13>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaUsageServiceTier
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller14>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaWebFetchToolResultErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.AllowedCaller15>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Beta.Messages.BetaWebSearchToolResultErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Beta.Messages.ServiceTier>(),
            new ApiEnumConverter<string, Batches::ProcessingStatus>(),
            new ApiEnumConverter<string, Batches::ServiceTier>(),
            new ApiEnumConverter<string, Type>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
