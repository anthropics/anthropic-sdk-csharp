using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Models.Beta;
using Messages = Anthropic.Models.Messages;

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
public sealed record class CompletionCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

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
            if (!this.BodyProperties.TryGetValue("max_tokens_to_sample", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "max_tokens_to_sample",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.BodyProperties["max_tokens_to_sample"] = JsonSerializer.SerializeToElement(value);
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
            if (!this.BodyProperties.TryGetValue("model", out JsonElement element))
                throw new ArgumentOutOfRangeException("model", "Missing required argument");

            return JsonSerializer.Deserialize<Messages::Model>(element)
                ?? throw new ArgumentNullException("model");
        }
        set { this.BodyProperties["model"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.BodyProperties.TryGetValue("prompt", out JsonElement element))
                throw new ArgumentOutOfRangeException("prompt", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("prompt");
        }
        set { this.BodyProperties["prompt"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An object describing metadata about the request.
    /// </summary>
    public Messages::Metadata? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Messages::Metadata?>(element);
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Sequences that will cause the model to stop generating.
    ///
    /// Our models stop on `"\n\nHuman:"`, and may include additional built-in stop
    /// sequences in the future. By providing the stop_sequences parameter, you may
    /// include additional strings that will cause the model to stop generating.
    /// </summary>
    public List<string>? StopSequences
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("stop_sequences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element);
        }
        set { this.BodyProperties["stop_sequences"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.BodyProperties.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.BodyProperties["stream"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.BodyProperties.TryGetValue("temperature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element);
        }
        set { this.BodyProperties["temperature"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.BodyProperties.TryGetValue("top_k", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.BodyProperties["top_k"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.BodyProperties.TryGetValue("top_p", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element);
        }
        set { this.BodyProperties["top_p"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public List<AnthropicBeta>? Betas
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("betas", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AnthropicBeta>?>(element);
        }
        set { this.HeaderProperties["betas"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IAnthropicClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/complete")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IAnthropicClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
