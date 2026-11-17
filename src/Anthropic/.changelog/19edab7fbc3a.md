perf(client): allocate less memory for large image and PDF requests

Request bodies no longer escape `+`, `<`, `>`, `&`, `'`, backticks or most non-ASCII text as `\uXXXX`. A body that the SDK rewrites stays escaped: requests through `AnthropicVertexClient` and `AnthropicBedrockClient`, and some requests through `AnthropicBedrockMantleClient` and `BetaRefusalFallbackHandler`. The JSON means the same, but custom HTTP handlers now see non-ASCII UTF-8 bytes. The raw JSON text that models and unions keep (`GetRawText()`) changes in the same way; `ToString()` does not.
