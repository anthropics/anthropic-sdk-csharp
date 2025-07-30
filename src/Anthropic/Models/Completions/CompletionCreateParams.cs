using Anthropic = Anthropic;
using Beta = Anthropic.Models.Beta;
using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Messages = Anthropic.Models.Messages;
using System = System;
using Text = System.Text;

namespace Anthropic.Models.Completions;

/// <summary>
/// [Legacy] Create a Text Completion.
///
/// The Text Completions API is a legacy API. We recommend using the [Messages API](https://docs.anthropic.com/en/api/messages)
/// going forward.
///
/// Future models and features will not be compatible with Text Completions. See our
/// [migration guide](https://docs.anthropic.com/en/api/migrating-from-text-completions-to-messages)
/// for guidance in migrating from Text Completions to Messages.
/// </summary>
public sealed record class CompletionCreateParams : Anthropic::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The maximum number of tokens to generate before stopping.
    ///
    /// Note that our models may stop _before_ reaching this maximum. This parameter
    /// only specifies the absolute maximum number of tokens to generate.
    /// </summary>
    public required long MaxTokensToSample
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "max_tokens_to_sample",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "max_tokens_to_sample",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.BodyProperties["max_tokens_to_sample"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
    /// for additional details and options.
    /// </summary>
    public required Messages::Model Model
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("model", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("model", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Messages::Model>(element)
                ?? throw new System::ArgumentNullException("model");
        }
        set { this.BodyProperties["model"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The prompt that you want Claude to complete.
    ///
    /// For proper response generation you will need to format your prompt using alternating
    /// `\n\nHuman:` and `\n\nAssistant:` conversational turns. For example:
    ///
    /// ``` "\n\nHuman: {userQuestion}\n\nAssistant:" ```
    ///
    /// See [prompt validation](https://docs.anthropic.com/en/api/prompt-validation)
    /// and our guide to [prompt design](https://docs.anthropic.com/en/docs/intro-to-prompting)
    /// for more details.
    /// </summary>
    public required string Prompt
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("prompt", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "prompt",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("prompt");
        }
        set { this.BodyProperties["prompt"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An object describing metadata about the request.
    /// </summary>
    public Messages::Metadata? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Messages::Metadata?>(element);
        }
        set { this.BodyProperties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Sequences that will cause the model to stop generating.
    ///
    /// Our models stop on `"\n\nHuman:"`, and may include additional built-in stop
    /// sequences in the future. By providing the stop_sequences parameter, you may
    /// include additional strings that will cause the model to stop generating.
    /// </summary>
    public Generic::List<string>? StopSequences
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("stop_sequences", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.BodyProperties["stop_sequences"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Whether to incrementally stream the response using server-sent events.
    ///
    /// See [streaming](https://docs.anthropic.com/en/api/streaming) for details.
    /// </summary>
    public bool? Stream
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("stream", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.BodyProperties["stream"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Amount of randomness injected into the response.
    ///
    /// Defaults to `1.0`. Ranges from `0.0` to `1.0`. Use `temperature` closer to `0.0`
    /// for analytical / multiple choice, and closer to `1.0` for creative and generative tasks.
    ///
    /// Note that even with `temperature` of `0.0`, the results will not be fully deterministic.
    /// </summary>
    public double? Temperature
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("temperature", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.BodyProperties["temperature"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only sample from the top K options for each subsequent token.
    ///
    /// Used to remove "long tail" low probability responses. [Learn more technical
    /// details here](https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277).
    ///
    /// Recommended for advanced use cases only. You usually only need to use `temperature`.
    /// </summary>
    public long? TopK
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("top_k", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.BodyProperties["top_k"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Use nucleus sampling.
    ///
    /// In nucleus sampling, we compute the cumulative distribution over all the options
    /// for each subsequent token in decreasing probability order and cut it off once
    /// it reaches a particular probability specified by `top_p`. You should either
    /// alter `temperature` or `top_p`, but not both.
    ///
    /// Recommended for advanced use cases only. You usually only need to use `temperature`.
    /// </summary>
    public double? TopP
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("top_p", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.BodyProperties["top_p"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public Generic::List<Beta::AnthropicBeta>? Betas
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("betas", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<Beta::AnthropicBeta>?>(element);
        }
        set { this.HeaderProperties["betas"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Anthropic::IAnthropicClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/complete")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(
        Http::HttpRequestMessage request,
        Anthropic::IAnthropicClient client
    )
    {
        Anthropic::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Anthropic::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
