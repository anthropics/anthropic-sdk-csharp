# Changelog

## 0.2.0 (2026-10-14)

### Features

* **client:** add native support for OpenTelemetry tracing

  To get the SDK's spans, add the `com.anthropic.sdk.csharp*` source to your tracer provider. To disable, initialize the client with `OpenTelemetry = false` or set `ANTHROPIC_OPEN_TELEMETRY=false`. Learn more in the [documentation](https://platform.claude.com/docs/en/manage-claude/opentelemetry/sdk).
