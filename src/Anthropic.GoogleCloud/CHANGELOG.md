# Changelog

## [1.0.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/GoogleCloud-v1.0.0...GoogleCloud-v1.0.1) (2026-10-22)

### Bug Fixes

* **google-cloud:** send user profiles requests to the organization endpoint

### Documentation

* **google-cloud:** update the product name

## [1.0.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/GoogleCloud-v0.3.0...GoogleCloud-v1.0.0) (2026-10-21)

### ⚠ BREAKING CHANGES

* **api:** add support for new API version 2026-10-21

### Features

* **api:** add support for new API version 2026-10-21

## [0.3.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/GoogleCloud-v0.2.0...GoogleCloud-v0.3.0) (2026-10-20)

### Features

* **google-cloud:** use the v1 endpoints and add the organization endpoint

## 0.2.0 (2026-10-14)

### Features

* **client:** add native support for OpenTelemetry tracing

  To get the SDK's spans, add the `com.anthropic.sdk.csharp*` source to your tracer provider. To disable, initialize the client with `OpenTelemetry = false` or set `ANTHROPIC_OPEN_TELEMETRY=false`. Learn more in the [documentation](https://platform.claude.com/docs/en/manage-claude/opentelemetry/sdk).
