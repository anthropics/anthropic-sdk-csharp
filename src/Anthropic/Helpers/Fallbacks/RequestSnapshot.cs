using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// A snapshot of a beta <c>/v1/messages</c> request, held for retrying it through the fallback
/// chain.
///
/// <para>The original <see cref="HttpRequestMessage"/> can't serve the retries itself: requests
/// are single-send, and the caller disposes the request (and its content) as soon as response
/// headers arrive: before a buffered retry, and long before the hop requests a spliced stream
/// issues while its body is being read. So everything needed is captured eagerly, and each
/// retry is minted as a fresh request from the captured pieces.</para>
/// </summary>
internal sealed class RequestSnapshot
{
    readonly Uri _uri;
    readonly Version _version;
#if NET
    // Options replaced Properties in net5.0; snapshot whichever this TFM has, so hop requests
    // carry the caller's per-request options (resilience settings, custom middleware keys, ...).
    readonly HttpVersionPolicy _versionPolicy;
    readonly IReadOnlyList<KeyValuePair<string, object?>> _options;
#else
    readonly IReadOnlyList<KeyValuePair<string, object>> _properties;
#endif

    /// <param name="uri">The request URI, already null-checked by the caller's gate.</param>
    /// <param name="request">Read here and released, since the caller disposes it once
    /// response headers arrive.</param>
    public RequestSnapshot(Uri uri, HttpRequestMessage request)
    {
        _uri = uri;
        _version = request.Version;
#if NET
        _versionPolicy = request.VersionPolicy;
        _options = [.. request.Options];
#else
        _properties = [.. request.Properties];
#endif
    }

    public required IReadOnlyList<BetaFallbackParam> Entries { get; init; }

    public required FallbackDiagnostics Diagnostics { get; init; }

    public required IReadOnlyList<KeyValuePair<string, string[]>> Headers { get; init; }

    public required IReadOnlyList<KeyValuePair<string, string[]>> ContentHeaders { get; init; }

    public required byte[] BodyBytes { get; init; }

    public required BetaFallbackState? State { get; init; }

    public required int InitialIndex { get; init; }

    public required bool IsStreaming { get; init; }

    /// <summary>
    /// Returns a request with the entry at the given index applied (-1 = the original request),
    /// plus the previous refusal's <c>fallback_credit_token</c>, if any.
    /// </summary>
    public HttpRequestMessage Request(int index, string? fallbackCreditToken = null)
    {
        if (index == -1)
        {
            return Build(BodyBytes);
        }

        var body = EffectiveBody(index);
        if (fallbackCreditToken != null)
        {
            body["fallback_credit_token"] = CreditTokenNode(fallbackCreditToken);
        }
        return Build(Encoding.UTF8.GetBytes(body.ToJsonString()));
    }

    /// <summary>
    /// Renders the token in the object form with <c>best_effort</c> mode, so a token-layer
    /// failure serves the retry at normal price instead of rejecting it — the outcome is
    /// then reported on the response's <c>usage.fallback_credit</c>.
    /// </summary>
    static JsonNode? CreditTokenNode(string token) =>
        JsonSerializer.SerializeToNode(
            new BetaFallbackCreditTokenParam { Token = token, Mode = Mode.BestEffort },
            ModelBase.SerializerOptions
        );

    /// <summary>
    /// Returns the body with the entry at the given index applied (-1 = the original body).
    /// </summary>
    JsonObject EffectiveBody(int index)
    {
        var body = (JsonObject)JsonNode.Parse(BodyBytes)!;
        if (index == -1)
        {
            return body;
        }
        // The entry's raw fields are exactly its set params (`model`, optional overrides, and
        // any extra properties), so overlaying them applies the entry as a patch on the
        // original request: a set field overrides, a field explicitly set to null unsets the
        // original param — absent from the retried request, not sent as JSON null.
        foreach (var field in Entries[index].RawData)
        {
            if (field.Key == "output_config" && field.Value.ValueKind == JsonValueKind.Object)
            {
                PatchObject(body, field.Key, field.Value);
            }
            else
            {
                Patch(body, field.Key, field.Value);
            }
        }
        return body;
    }

    /// <summary>Applies one patch field: JSON null removes the key, anything else sets
    /// it.</summary>
    static void Patch(JsonObject target, string key, JsonElement value)
    {
        if (value.ValueKind == JsonValueKind.Null)
        {
            target.Remove(key);
        }
        else
        {
            target[key] = JsonNode.Parse(value.GetRawText());
        }
    }

    /// <summary>
    /// Patches an object-valued param one level deep: each subfield of the entry's object is a
    /// patch against the original object's subfields — set overrides, null unsets, and subfields
    /// the entry doesn't mention keep the original values. An original request without the
    /// object gains one holding just the entry's set subfields. A patch that leaves no subfields
    /// removes the param whole — never sent as an empty object.
    /// </summary>
    static void PatchObject(JsonObject body, string key, JsonElement patch)
    {
        var target = body[key] as JsonObject ?? [];
        foreach (var subfield in patch.EnumerateObject())
        {
            Patch(target, subfield.Name, subfield.Value);
        }
        if (target.Count == 0)
        {
            body.Remove(key);
        }
        else
        {
            body[key] = target;
        }
    }

    /// <summary>
    /// Returns the hop request for a spliced stream: the initial request's body with the model
    /// and credit token swapped in and the continuation appended as a trailing assistant turn.
    /// </summary>
    public HttpRequestMessage HopRequest(
        string model,
        string fallbackCreditToken,
        IReadOnlyList<JsonObject> continuation
    )
    {
        // Rebuilt on every attempt so each request starts from the body the token was minted
        // against, the initial request's; a pinned entry's overrides are included, since the
        // initial request carried them and the token binds to them.
        var body = EffectiveBody(InitialIndex);

        body["model"] = model;
        body["fallback_credit_token"] = CreditTokenNode(fallbackCreditToken);

        // The token is only redeemable against the same body, so model, fallback_credit_token,
        // and the one appended assistant turn are the only permitted deltas; anything else,
        // per-entry BetaFallbackParam overrides included, is a 400.
        if (continuation.Count > 0)
        {
            if (body["messages"] is not JsonArray messages)
            {
                messages = [];
                body["messages"] = messages;
            }
            JsonArray content = [];
            foreach (var block in continuation)
            {
                content.Add(block.DeepClone());
            }
            messages.Add(new JsonObject { ["role"] = "assistant", ["content"] = content });
        }

        return Build(Encoding.UTF8.GetBytes(body.ToJsonString()));
    }

    /// <summary>
    /// The model the request at the given index was sent with, as the caller (or the entry's
    /// override) spelled it (-1 = the original request).
    /// </summary>
    public string ModelAt(int index) =>
        EffectiveBody(index)["model"] is JsonValue value && value.TryGetValue(out string? model)
            ? model
            : "";

    /// <summary>Pins requests sharing the state to the entry at the given index.</summary>
    public void Pin(int index)
    {
        if (State != null)
        {
            State.Index = index;
        }
        else
        {
            Diagnostics.WarnMissingStateOnce();
        }
    }

    HttpRequestMessage Build(byte[] bodyBytes)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _uri) { Version = _version };
#if NET
        request.VersionPolicy = _versionPolicy;
        foreach (var option in _options)
        {
            ((IDictionary<string, object?>)request.Options)[option.Key] = option.Value;
        }
#else
        foreach (var property in _properties)
        {
            request.Properties[property.Key] = property.Value;
        }
#endif
        foreach (var header in Headers)
        {
            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
        ByteArrayContent content = new(bodyBytes);
        foreach (var header in ContentHeaders)
        {
            content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
        request.Content = content;
        return request;
    }
}
