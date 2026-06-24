# Changelog

## 0.5.1 (2026-06-24)

Full Changelog: [Aws-v0.5.0...Aws-v0.5.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/Aws-v0.5.0...Aws-v0.5.1)

### Chores

* **internal:** add lock file ([#63](https://github.com/anthropics/anthropic-sdk-csharp/issues/63)) ([6a75efb](https://github.com/anthropics/anthropic-sdk-csharp/commit/6a75efbe17fc5741cd809bcb6d4ce4514eb0fd37))

## 0.5.0 (2026-06-09)

Full Changelog: [Aws-v0.4.0...Aws-v0.5.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Aws-v0.4.0...Aws-v0.5.0)

### Features

* **api:** add support for claude-mythos-5 and claude-fable-5, with support for server-side fallbacks on refusal ([a9d68ed](https://github.com/anthropics/anthropic-sdk-csharp/commit/a9d68ed7e6b023429943e8f9662a7d45bc407890))
* **client:** adds client-side fallbacks middleware for API providers that do not support server-side fallbacks ([a9d68ed](https://github.com/anthropics/anthropic-sdk-csharp/commit/a9d68ed7e6b023429943e8f9662a7d45bc407890))

## 0.4.0 (2026-05-11)

Full Changelog: [Aws-v0.3.0...Aws-v0.4.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Aws-v0.3.0...Aws-v0.4.0)

### Features

* **aws:** Add AWS client for Claude Platform on AWS ([321c71c](https://github.com/anthropics/anthropic-sdk-csharp/commit/321c71c184a16be4cc39e9943f2ec13babf91e34))


### Bug Fixes

* **aws,bedrock:** preserve multipart Content-Type and collapse multi-value headers in SigV4 signing; add SSO package deps ([#837](https://github.com/anthropics/anthropic-sdk-csharp/issues/837)) ([9aa2083](https://github.com/anthropics/anthropic-sdk-csharp/commit/9aa20832da1ad509afeeeb9d55bca84959672ef4))

## 0.3.0 (2026-05-05)

Full Changelog: [Aws-v0.2.2...Aws-v0.3.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Aws-v0.2.2...Aws-v0.3.0)

### Features

* **client:** add Workload Identity Federation, interactive OAuth, and auth profiles ([#832](https://github.com/anthropics/anthropic-sdk-csharp/issues/832)) ([cb1a18b](https://github.com/anthropics/anthropic-sdk-csharp/commit/cb1a18bd44f44838dd558ee5e74c40800f977703))


### Bug Fixes

* **client:** Adjust credentials auth to be consistent with other SDKs ([#829](https://github.com/anthropics/anthropic-sdk-csharp/issues/829)) ([7dd7106](https://github.com/anthropics/anthropic-sdk-csharp/commit/7dd7106d73553e5768513d9aa3e8b3b523b789ee))

## 0.2.2 (2026-04-07)

Full Changelog: [Aws-v0.2.1...Aws-v0.2.2](https://github.com/anthropics/anthropic-sdk-csharp/compare/Aws-v0.2.1...Aws-v0.2.2)

### Chores

* **client:** internal updates ([744b690](https://github.com/anthropics/anthropic-sdk-csharp/commit/744b6906011c98fa8645caffffd6261ad07a55f9))

## 0.2.1 (2026-04-03)

Full Changelog: [Aws-v0.2.0...Aws-v0.2.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/Aws-v0.2.0...Aws-v0.2.1)

### Chores

* **client:** internal updates ([744b690](https://github.com/anthropics/anthropic-sdk-csharp/commit/744b6906011c98fa8645caffffd6261ad07a55f9))

## 0.2.0 (2026-04-01)

Full Changelog: [Aws-v0.1.0...Aws-v0.2.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Aws-v0.1.0...Aws-v0.2.0)

### Features

* prepare aws package ([#770](https://github.com/anthropics/anthropic-sdk-csharp/issues/770)) ([b10ef0f](https://github.com/anthropics/anthropic-sdk-csharp/commit/b10ef0fe5c8d2c64035da7f89182e0a903530d89))
