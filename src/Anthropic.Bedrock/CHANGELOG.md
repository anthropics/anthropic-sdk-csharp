# Changelog

## 0.11.0 (2026-07-16)

Full Changelog: [Bedrock-v0.10.2...Bedrock-v0.11.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.10.2...Bedrock-v0.11.0)

### Features

* **api:** add support for dreaming ([1228406](https://github.com/anthropics/anthropic-sdk-csharp/commit/1228406b6983f844738e88965e6d837347b62532))
* **api:** add support for MCP Tunnels ([adea206](https://github.com/anthropics/anthropic-sdk-csharp/commit/adea2067ddf9253ba37ed21b79cb34e1082cae31))

## 0.10.2 (2026-06-24)

Full Changelog: [Bedrock-v0.10.1...Bedrock-v0.10.2](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.10.1...Bedrock-v0.10.2)

### Chores

* **internal:** add lock file ([#63](https://github.com/anthropics/anthropic-sdk-csharp/issues/63)) ([6a75efb](https://github.com/anthropics/anthropic-sdk-csharp/commit/6a75efbe17fc5741cd809bcb6d4ce4514eb0fd37))

## 0.10.1 (2026-06-15)

Full Changelog: [Bedrock-v0.10.0...Bedrock-v0.10.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.10.0...Bedrock-v0.10.1)

### Bug Fixes

* **bedrock:** never send first-party env credentials to AWS ([#43](https://github.com/anthropics/anthropic-sdk-csharp/issues/43)) ([a22084e](https://github.com/anthropics/anthropic-sdk-csharp/commit/a22084e557ee826c887ab5241b742a79caecdc9a))

## 0.10.0 (2026-06-09)

Full Changelog: [Bedrock-v0.9.0...Bedrock-v0.10.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.9.0...Bedrock-v0.10.0)

### Features

* **api:** add support for Managed Agents deployments and environment variable credentials ([01bc60a](https://github.com/anthropics/anthropic-sdk-csharp/commit/01bc60a83bf0bf95ae00d88ca48f9587644733a1))

## 0.9.0 (2026-06-09)

Full Changelog: [Bedrock-v0.8.1...Bedrock-v0.9.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.8.1...Bedrock-v0.9.0)

### Features

* **api:** add support for claude-mythos-5 and claude-fable-5, with support for server-side fallbacks on refusal ([a9d68ed](https://github.com/anthropics/anthropic-sdk-csharp/commit/a9d68ed7e6b023429943e8f9662a7d45bc407890))
* **client:** adds client-side fallbacks middleware for API providers that do not support server-side fallbacks ([a9d68ed](https://github.com/anthropics/anthropic-sdk-csharp/commit/a9d68ed7e6b023429943e8f9662a7d45bc407890))

## 0.8.1 (2026-05-11)

Full Changelog: [Bedrock-v0.8.0...Bedrock-v0.8.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.8.0...Bedrock-v0.8.1)

### Bug Fixes

* **aws,bedrock:** preserve multipart Content-Type and collapse multi-value headers in SigV4 signing; add SSO package deps ([#837](https://github.com/anthropics/anthropic-sdk-csharp/issues/837)) ([9aa2083](https://github.com/anthropics/anthropic-sdk-csharp/commit/9aa20832da1ad509afeeeb9d55bca84959672ef4))

## 0.8.0 (2026-05-06)

Full Changelog: [Bedrock-v0.7.0...Bedrock-v0.8.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.7.0...Bedrock-v0.8.0)

### Features

* **api:** add support for Managed Agents multiagents and outcomes, webhooks, vault validation ([31b3066](https://github.com/anthropics/anthropic-sdk-csharp/commit/31b306669314992e0b4a03a66c4c973662486ee7))

## 0.7.0 (2026-05-05)

Full Changelog: [Bedrock-v0.6.0...Bedrock-v0.7.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.6.0...Bedrock-v0.7.0)

### Features

* **client:** add Workload Identity Federation, interactive OAuth, and auth profiles ([#832](https://github.com/anthropics/anthropic-sdk-csharp/issues/832)) ([cb1a18b](https://github.com/anthropics/anthropic-sdk-csharp/commit/cb1a18bd44f44838dd558ee5e74c40800f977703))


### Bug Fixes

* **client:** Adjust credentials auth to be consistent with other SDKs ([#829](https://github.com/anthropics/anthropic-sdk-csharp/issues/829)) ([7dd7106](https://github.com/anthropics/anthropic-sdk-csharp/commit/7dd7106d73553e5768513d9aa3e8b3b523b789ee))

## 0.6.0 (2026-04-23)

Full Changelog: [Bedrock-v0.5.0...Bedrock-v0.6.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.5.0...Bedrock-v0.6.0)

### Features

* **api:** CMA Memory public beta ([011860b](https://github.com/anthropics/anthropic-sdk-csharp/commit/011860bdbce23dd5c04421bd33eae30aefc2bf34))


### Chores

* add missing interface method ([9e9a5b3](https://github.com/anthropics/anthropic-sdk-csharp/commit/9e9a5b37a5bbefa6ad53d6349e447e272b6ec091))

## 0.5.0 (2026-04-16)

Full Changelog: [Bedrock-v0.4.0...Bedrock-v0.5.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.4.0...Bedrock-v0.5.0)

### Features

* **api:** add claude-opus-4-7, token budgets and user_profiles ([93c87dd](https://github.com/anthropics/anthropic-sdk-csharp/commit/93c87dd4d3a9179f7b5f3280fdb8ab27297607bb))

## 0.4.0 (2026-04-14)

Full Changelog: [Bedrock-v0.3.0...Bedrock-v0.4.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.3.0...Bedrock-v0.4.0)

### Features

* **bedrock:** use auth header for mantle client ([#793](https://github.com/anthropics/anthropic-sdk-csharp/issues/793)) ([2a2e2c3](https://github.com/anthropics/anthropic-sdk-csharp/commit/2a2e2c3cc4740381f52a364acefeb25656abcfcd))

## 0.3.0 (2026-04-08)

Full Changelog: [Bedrock-v0.2.0...Bedrock-v0.3.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.2.0...Bedrock-v0.3.0)

### Features

* **api:** add support for Claude Managed Agents ([aa4b900](https://github.com/anthropics/anthropic-sdk-csharp/commit/aa4b900c386fa073fc82db4f29bcb9473c8b6282))

## 0.2.0 (2026-04-07)

Full Changelog: [Bedrock-v0.1.2...Bedrock-v0.2.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.1.2...Bedrock-v0.2.0)

### Features

* **bedrock:** Create Bedrock Mantle client ([#768](https://github.com/anthropics/anthropic-sdk-csharp/issues/768)) ([7141e34](https://github.com/anthropics/anthropic-sdk-csharp/commit/7141e3487d09f8e02567359d438e48061554b858))

## 0.1.2 (2026-04-01)

Full Changelog: [Bedrock-v0.1.1...Bedrock-v0.1.2](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.1.1...Bedrock-v0.1.2)

### Bug Fixes

* **client:** update Bearer scheme casing to match AWS requirement ([#152](https://github.com/anthropics/anthropic-sdk-csharp/issues/152)) ([aa71d57](https://github.com/anthropics/anthropic-sdk-csharp/commit/aa71d5766f1053501f88e97519205cd41e9e2371))

## 0.1.1 (2026-03-31)

Full Changelog: [Bedrock-v0.1.0...Bedrock-v0.1.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.1.0...Bedrock-v0.1.1)

### Bug Fixes

* handle oversized SSE events in Bedrock SseEventContentWrapper ([#147](https://github.com/anthropics/anthropic-sdk-csharp/issues/147)) ([dcbf8cc](https://github.com/anthropics/anthropic-sdk-csharp/commit/dcbf8ccb4dc4f1d67fe85e3ff1248517bea6af23))

## 0.1.0 (2026-03-16)

Full Changelog: [Bedrock-v0.0.1...Bedrock-v0.1.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Bedrock-v0.0.1...Bedrock-v0.1.0)

### Features

* **tests:** update mock server ([775f7d1](https://github.com/anthropics/anthropic-sdk-csharp/commit/775f7d174fe5729675c7fe91d1c7bd9749e7c053))


### Bug Fixes

* **docs:** make xml comments valid ([#141](https://github.com/anthropics/anthropic-sdk-csharp/issues/141)) ([6251881](https://github.com/anthropics/anthropic-sdk-csharp/commit/62518812ab63e2ef7162e803167e821815160661))


### Chores

* **client:** update microsoft.bcl.memory ([5fcec90](https://github.com/anthropics/anthropic-sdk-csharp/commit/5fcec90dffb11bb3f99ff5ecd919d193c8994abb))
* **docs:** add undocumented parameters to readme ([1d996bb](https://github.com/anthropics/anthropic-sdk-csharp/commit/1d996bb26dc18826832dc56ed44fb82669f1ee68))
* **docs:** minor example cleanup ([e14da75](https://github.com/anthropics/anthropic-sdk-csharp/commit/e14da75bf138420ed889c2fbc0b6f80956345e4d))

## 0.0.1 (2026-02-12)

Full Changelog: [...Bedrock-v0.0.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/...Bedrock-v0.0.1)

### Features

* Add vertex provider ([#108](https://github.com/anthropics/anthropic-sdk-csharp/issues/108)) ([154b77b](https://github.com/anthropics/anthropic-sdk-csharp/commit/154b77beb7957e731e1ff0620bf913d632897c47))
