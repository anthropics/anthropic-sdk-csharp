# Changelog

## 12.9.0 (2026-03-16)

Full Changelog: [Anthropic-v12.8.0...Anthropic-v12.9.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.8.0...Anthropic-v12.9.0)

### Features

* **api:** change array_format to brackets ([4e216d2](https://github.com/anthropics/anthropic-sdk-csharp/commit/4e216d2851348627da6023c4647fdcecca0b06b5))
* **api:** chore(config): clean up model enum list ([#31](https://github.com/anthropics/anthropic-sdk-csharp/issues/31)) ([62852b4](https://github.com/anthropics/anthropic-sdk-csharp/commit/62852b48db86aefdd739b450b1d8c28575d06cf0))
* **api:** remove publishing section from cli target ([b7194a2](https://github.com/anthropics/anthropic-sdk-csharp/commit/b7194a2918c9ccaac1762df1b229a344cb6e62a7))
* **tests:** update mock server ([775f7d1](https://github.com/anthropics/anthropic-sdk-csharp/commit/775f7d174fe5729675c7fe91d1c7bd9749e7c053))


### Bug Fixes

* **docs:** make xml comments valid ([#141](https://github.com/anthropics/anthropic-sdk-csharp/issues/141)) ([6251881](https://github.com/anthropics/anthropic-sdk-csharp/commit/62518812ab63e2ef7162e803167e821815160661))
* **docs:** make xml syntactically correct ([b91c421](https://github.com/anthropics/anthropic-sdk-csharp/commit/b91c4215c1cf103aeff39a4fd08067a4a54f3d67))
* **client:** preserve RawRepresentation in IChatClient system message mapping ([4a324d7](https://github.com/anthropics/anthropic-sdk-csharp/commit/4a324d74fe8c835b6e1df20bd5b3a69c4a071560))


### Chores

* **client:** remove print statement ([#137](https://github.com/anthropics/anthropic-sdk-csharp/issues/137)) ([efd712b](https://github.com/anthropics/anthropic-sdk-csharp/commit/efd712bd707c87f554364dd6ecdf7573cd2d338a))
* **client:** update formatting ([621e6d6](https://github.com/anthropics/anthropic-sdk-csharp/commit/621e6d60437adf29d07b2de7c5a5e5994ca1732c))
* **docs:** add undocumented parameters to readme ([1d996bb](https://github.com/anthropics/anthropic-sdk-csharp/commit/1d996bb26dc18826832dc56ed44fb82669f1ee68))
* **internal:** codegen related update ([be001d7](https://github.com/anthropics/anthropic-sdk-csharp/commit/be001d73a7998111129f2c3ad529d9f39dd85083))
* **internal:** codegen related update ([55f00a1](https://github.com/anthropics/anthropic-sdk-csharp/commit/55f00a1b684ef39f00a026b8679eb405884492d0))


### Refactors

* **internal:** default headers ([cca4f5a](https://github.com/anthropics/anthropic-sdk-csharp/commit/cca4f5a996d7eed7925cf995e4920995a7bcc469))

## 12.8.0 (2026-02-19)

Full Changelog: [Anthropic-v12.7.0...Anthropic-v12.8.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.7.0...Anthropic-v12.8.0)

### Features

* **api:** Add top-level cache control (automatic caching) ([c294cb3](https://github.com/anthropics/anthropic-sdk-csharp/commit/c294cb3eec22f5ad865261d0a5acaee9e81d635c))
* **api:** Deprecate haiku-3 ([e087138](https://github.com/anthropics/anthropic-sdk-csharp/commit/e0871384ccc36aa31a0036e8cedbd2344b52522e))

## 12.7.0 (2026-02-18)

Full Changelog: [Anthropic-v12.6.0...Anthropic-v12.7.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.6.0...Anthropic-v12.7.0)

### Features

* **api:** fix shared UserLocation and error code types ([7dccdbf](https://github.com/anthropics/anthropic-sdk-csharp/commit/7dccdbf2fd7739d67e004684fe637a704f1735c9))
* **api:** manual updates ([0cd161c](https://github.com/anthropics/anthropic-sdk-csharp/commit/0cd161c08db1530f69e86957a921d2c739d96e55))

## 12.6.0 (2026-02-17)

Full Changelog: [Anthropic-v12.5.0...Anthropic-v12.6.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.5.0...Anthropic-v12.6.0)

### Features

* **api:** Releasing claude-sonnet-4-6 ([7e4730f](https://github.com/anthropics/anthropic-sdk-csharp/commit/7e4730f345d5beee1152b12ea20e130ecc0f8cf4))
* **client:** add equality and tostring for multipart data ([eebd5d5](https://github.com/anthropics/anthropic-sdk-csharp/commit/eebd5d557dd87f7a8f41aaac713724dcf0e3f765))
* warn when thinking is enabled for certain models ([#383](https://github.com/anthropics/anthropic-sdk-csharp/issues/383)) ([3f7f3c6](https://github.com/anthropics/anthropic-sdk-csharp/commit/3f7f3c6085434777b21180508bcd8213516c22b5))


### Bug Fixes

* **api:** fix spec errors ([99a28b3](https://github.com/anthropics/anthropic-sdk-csharp/commit/99a28b38160483dbfa9439f51b9a65607e313bc1))
* **client:** validate unions properly ([d56c992](https://github.com/anthropics/anthropic-sdk-csharp/commit/d56c992741c5233ad6f7a76ea664a5b8d9ef0cbb))

## 12.5.0 (2026-02-12)

Full Changelog: [Anthropic-v12.4.0...Anthropic-v12.5.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.4.0...Anthropic-v12.5.0)

### Features

* **api:** enabling fast-mode in claude-opus-4-6 ([d468eb3](https://github.com/anthropics/anthropic-sdk-csharp/commit/d468eb30eda01631bed6e83d9085fa08fbb0b10b))
* **client:** add union variant names for C# ([ad3d327](https://github.com/anthropics/anthropic-sdk-csharp/commit/ad3d327c0dc11803e9fc46ae7f81d7fb1d5bcbaa))
* **client:** enable upload endpoint ([90fef13](https://github.com/anthropics/anthropic-sdk-csharp/commit/90fef1336fde7c5fec2fdd13f025c231b313278d))
* **client:** streaming aggregators ([#105](https://github.com/anthropics/anthropic-sdk-csharp/issues/105)) ([7cd71a0](https://github.com/anthropics/anthropic-sdk-csharp/commit/7cd71a06fe80f938ab8dc3794e3e95f8dda553af))


### Bug Fixes

* **client:** handle edge case with renamed variable ([3fc3fa7](https://github.com/anthropics/anthropic-sdk-csharp/commit/3fc3fa7426f5d3e920820c55f1401830766e662f))
* **client:** improve behaviour for comma-delimited binary content in multipart requests ([9008576](https://github.com/anthropics/anthropic-sdk-csharp/commit/9008576a2dde10c416e8aaeb41f714475229b5a0))

## 12.4.0 (2026-02-05)

Full Changelog: [Anthropic-v12.3.0...Anthropic-v12.4.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.3.0...Anthropic-v12.4.0)

### Features

* **api:** Release Claude Opus 4.6, adaptive thinking, and other features ([f40db86](https://github.com/anthropics/anthropic-sdk-csharp/commit/f40db86a00ff6136e26f04204c42c39da5f02d43))
* **client:** add common response headers to `HttpResponse` ([9834908](https://github.com/anthropics/anthropic-sdk-csharp/commit/98349082a391234569be16049f1a6a1f24c20100))


### Bug Fixes

* **client:** improve union equality method ([2f857bb](https://github.com/anthropics/anthropic-sdk-csharp/commit/2f857bbad40967cb13f689dd773a59d2ef55614d))
* update beta service to use output_config.format ([#110](https://github.com/anthropics/anthropic-sdk-csharp/issues/110)) ([5d1eb0a](https://github.com/anthropics/anthropic-sdk-csharp/commit/5d1eb0a84492af9fd4be666c6b8c34b03982699d))

## 12.3.0 (2026-01-29)

Full Changelog: [Anthropic-v12.2.0...Anthropic-v12.3.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.2.0...Anthropic-v12.3.0)

### Features

* **api:** add support for Structured Outputs in the Messages API ([6d3d655](https://github.com/anthropics/anthropic-sdk-csharp/commit/6d3d655e52c43c91e8837dda186e04984d5dcf62))
* **api:** migrate sending message format in output_config rather than output_format ([e24676b](https://github.com/anthropics/anthropic-sdk-csharp/commit/e24676bda5b1409059c65064d1bf52d09973d884))
* **client:** add `ToString` and `Equals` methods ([91fe9dd](https://github.com/anthropics/anthropic-sdk-csharp/commit/91fe9dd6ff1f17e1fb1347a749e08722e9d3565e))
* **client:** add `ToString` to `ApiEnum` ([6c1887d](https://github.com/anthropics/anthropic-sdk-csharp/commit/6c1887d3e5ae0f0744bb67a455b7c2dd066884ce))
* **client:** add Equals and ToString to params ([3be5397](https://github.com/anthropics/anthropic-sdk-csharp/commit/3be53975b406cca32cb0cd311a0cf684863855a8))


### Bug Fixes

* **client:** handle unions containing unknown types properly ([9dc5b92](https://github.com/anthropics/anthropic-sdk-csharp/commit/9dc5b92ae074c54e9287f6e7179a4b5c1dfe02b1))


### Chores

* change visibility of QueryString() and AddDefaultHeaders ([38a18f9](https://github.com/anthropics/anthropic-sdk-csharp/commit/38a18f9cb6a258a8c59c1478e001ce4ede35af52))
* **internal:** add copy constructor tests ([5915cfe](https://github.com/anthropics/anthropic-sdk-csharp/commit/5915cfe6b9a0df56b5acda9ac7cef0d89ae4dbe1))
* **internal:** codegen related update ([7b0a0e8](https://github.com/anthropics/anthropic-sdk-csharp/commit/7b0a0e862ac2adcdf05be8635662ca2f01b93ca9))
* **internal:** codegen related update ([fc997b8](https://github.com/anthropics/anthropic-sdk-csharp/commit/fc997b8829b7a6a89d9e52695a6f919a45f771ef))
* **internal:** codegen related update ([5e32bb5](https://github.com/anthropics/anthropic-sdk-csharp/commit/5e32bb5ed0488321c6809aab25c72a85a0296aa6))
* **internal:** improve HttpResponse qualification ([8b4d892](https://github.com/anthropics/anthropic-sdk-csharp/commit/8b4d892a18d6b05ed031bfecb1e78bfc0094cf47))
* **internal:** simplify imports ([8324572](https://github.com/anthropics/anthropic-sdk-csharp/commit/8324572350d980ea4695f2830320b4c70bd9125c))
* **internal:** version bump ([4e6f6dd](https://github.com/anthropics/anthropic-sdk-csharp/commit/4e6f6ddd0cfff4d301f7adf608256480e5d3703c))
* **readme:** remove beta warning now that we're in ga ([0738e65](https://github.com/anthropics/anthropic-sdk-csharp/commit/0738e6548fefbd207b016a3b05b45448ff71896e))
* **readme:** remove beta warning now that we're in ga ([7c4b745](https://github.com/anthropics/anthropic-sdk-csharp/commit/7c4b7457f7d32da04cf21865f8daff626901f286))

## 12.2.0 (2026-01-14)

Full Changelog: [Anthropic-v12.1.0...Anthropic-v12.2.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.1.0...Anthropic-v12.2.0)

### Features

* **client:** add helper functions for raw messages ([c38e0f1](https://github.com/anthropics/anthropic-sdk-csharp/commit/c38e0f12290a08e6cabd3648aafdb9ff6805ef1b))
* **client:** add more `ToString` implementations ([ebebe2a](https://github.com/anthropics/anthropic-sdk-csharp/commit/ebebe2a91c38de423dd1c8c66f458e18ddfefb99))
* **client:** add strong naming ([4feeae5](https://github.com/anthropics/anthropic-sdk-csharp/commit/4feeae5326bdafe703446ea9d7d59998e75b44a2))
* **client:** support `WithRawResponse` in Foundry client ([#92](https://github.com/anthropics/anthropic-sdk-csharp/issues/92)) ([39ffeb2](https://github.com/anthropics/anthropic-sdk-csharp/commit/39ffeb28ba31d8d6efd419e70399ef40c5a821bf))
* **client:** support accessing raw responses ([81ad4fe](https://github.com/anthropics/anthropic-sdk-csharp/commit/81ad4febea7ad4d467e551ac1105ccbdb7e6f936))


### Bug Fixes

* **client:** add missing serializer options ([f08055c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f08055c4c414f5a0178403236d93ed332e8f67e0))
* **client:** copy path params in params copy constructors ([23fd7c6](https://github.com/anthropics/anthropic-sdk-csharp/commit/23fd7c6f9d073f5178d4762add1586a11a165a15))
* **client:** ensure deep immutability for deep array/dict structures ([d9385f7](https://github.com/anthropics/anthropic-sdk-csharp/commit/d9385f70245608f7aaf79b799e6a2837e8b1f692))
* **client:** freeze models on property access ([4aec2c8](https://github.com/anthropics/anthropic-sdk-csharp/commit/4aec2c8efd1b7be8736bc4ee374c0a2e2c9af565))
* **client:** throw api enum errors as invalid data exception ([6028977](https://github.com/anthropics/anthropic-sdk-csharp/commit/60289772157c9644f3f3c39cdbc20d468916c351))
* **client:** union switch method type checks ([e0c4fcb](https://github.com/anthropics/anthropic-sdk-csharp/commit/e0c4fcb5f379210c52549a3ebf0a0648ca186946))
* **client:** use readonly type for param ([b00209c](https://github.com/anthropics/anthropic-sdk-csharp/commit/b00209c458cae1609354d1c1a87a463b0fd7c421))
* **internal:** accidental custom code ([2025fbb](https://github.com/anthropics/anthropic-sdk-csharp/commit/2025fbb9472bee6bbf84db2f17e3509a31cc8eae))
* **internal:** build ([74ac455](https://github.com/anthropics/anthropic-sdk-csharp/commit/74ac455672b22d37973b92400578a32b30196f1f))
* **internal:** remove redundant line ([ed85010](https://github.com/anthropics/anthropic-sdk-csharp/commit/ed8501035c018797edadcb2c2bfecdb4a08d6fff))
* **internal:** remove roundtrip tests for multipart params ([1e3f6e1](https://github.com/anthropics/anthropic-sdk-csharp/commit/1e3f6e15792b9aa8ce9cd9b210af1484c0909be8))
* use Properties initializer for InputSchema in IChatClient extensions ([#83](https://github.com/anthropics/anthropic-sdk-csharp/issues/83)) ([b4d9faf](https://github.com/anthropics/anthropic-sdk-csharp/commit/b4d9faf036c145727a722ba586bbb38d692b8464))


### Performance Improvements

* **client:** add json deserialization caching ([d9385f7](https://github.com/anthropics/anthropic-sdk-csharp/commit/d9385f70245608f7aaf79b799e6a2837e8b1f692))


### Chores

* **client:** consistently use serializer options ([d02b2fa](https://github.com/anthropics/anthropic-sdk-csharp/commit/d02b2faac56aa4ebaaf7d018f87c68f804e56f49))
* **client:** mark claude-3-5-haiku as deprecated ([b5f147c](https://github.com/anthropics/anthropic-sdk-csharp/commit/b5f147c4ea57e8932a1bfb4dd93cdca23cb7d23e))
* **client:** use mutable collections for union deserialization ([bd75f30](https://github.com/anthropics/anthropic-sdk-csharp/commit/bd75f309274287c39b9bd3a6cf4a40220387267d))
* **internal:** codegen related update ([8565b06](https://github.com/anthropics/anthropic-sdk-csharp/commit/8565b06cac5d068ff9ada0b6dd46dcbf26f183f9))
* **internal:** codegen related update ([df7fd3c](https://github.com/anthropics/anthropic-sdk-csharp/commit/df7fd3c77ddbb9f94e0419e6759b24c30e45dffb))
* **internal:** format ([3af90a7](https://github.com/anthropics/anthropic-sdk-csharp/commit/3af90a7314837e1ff517454abf502b340f4ce86a))
* **internal:** use better namespace aliases ([16b810a](https://github.com/anthropics/anthropic-sdk-csharp/commit/16b810aa749bbc6d83e15730548183fa2a4d8ea2))
* **readme:** remove beta warning now that we're in ga ([613b5ce](https://github.com/anthropics/anthropic-sdk-csharp/commit/613b5ce8acc3da8fd563941e20d0717f01a2ca5e))


### Refactors

* **client:** add `JsonDictionary` identity methods ([2c26557](https://github.com/anthropics/anthropic-sdk-csharp/commit/2c265578de729bbc17ee4df21119aaf965a1d5b0))
* **client:** make unions implement `ModelBase` ([8500f1e](https://github.com/anthropics/anthropic-sdk-csharp/commit/8500f1e194d94965cb06d7b2bbf39c6430e8bfbe))
* **internal:** `JsonElement` constant construction ([bb19b2b](https://github.com/anthropics/anthropic-sdk-csharp/commit/bb19b2b59c1af409b393af06c39fb67371f763d1))
* **internal:** unnest constant converter ([65a1eec](https://github.com/anthropics/anthropic-sdk-csharp/commit/65a1eec251d0080a4336a3236c83f0a59aa91be6))

## 12.1.0 (2026-01-06)

Full Changelog: [Anthropic-v12.0.1...Anthropic-v12.1.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.0.1...Anthropic-v12.1.0)

### Features

* **client:** add EnvironmentUrl ([d593feb](https://github.com/anthropics/anthropic-sdk-csharp/commit/d593feb073c2135e6532212f917a92283f452d97))
* **client:** add multipart form data support ([95a5da6](https://github.com/anthropics/anthropic-sdk-csharp/commit/95a5da65eb7ba004bcda4c803375ee094b3e0252))


### Bug Fixes

* **internal:** test nullability warnings ([df69317](https://github.com/anthropics/anthropic-sdk-csharp/commit/df69317d1af83dc9f596d8262aa9179105106d9b))


### Chores

* **client:** improve object instantiation ([686026e](https://github.com/anthropics/anthropic-sdk-csharp/commit/686026e27e917acd7a8a10f2ccc964f210f117c9))
* fix lint error ([d3bef74](https://github.com/anthropics/anthropic-sdk-csharp/commit/d3bef74a70da9faf737a80f6e9251a30c16f223e))
* **internal:** add stainless main project tag ([#282](https://github.com/anthropics/anthropic-sdk-csharp/issues/282)) ([9b6fdd1](https://github.com/anthropics/anthropic-sdk-csharp/commit/9b6fdd18a486e2d8d182be23bd8604fc5f2446e9))
* **internal:** share csproj properties with dir build props ([df69317](https://github.com/anthropics/anthropic-sdk-csharp/commit/df69317d1af83dc9f596d8262aa9179105106d9b))
* **internal:** use `Random.Shared` in newer .NET versions ([f87fa65](https://github.com/anthropics/anthropic-sdk-csharp/commit/f87fa6582c33d0fc124c3c08db9911b2ea46b0b0))
* **internal:** use better test examples ([df69317](https://github.com/anthropics/anthropic-sdk-csharp/commit/df69317d1af83dc9f596d8262aa9179105106d9b))

## 12.0.1 (2025-12-18)

Full Changelog: [Anthropic-v12.0.0...Anthropic-v12.0.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v12.0.0...Anthropic-v12.0.1)

### Documentation

* fix typos and resolve merge conflict in CHANGELOG ([#78](https://github.com/anthropics/anthropic-sdk-csharp/issues/78)) ([a6ccfa7](https://github.com/anthropics/anthropic-sdk-csharp/commit/a6ccfa7968391a00dc92db625e4344d252eb3c03))

## 12.0.0 (2025-12-10)

Full Changelog: [Anthropic-v11.0.0...Anthropic-v12.0.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/Anthropic-v11.0.0...Anthropic-v12.0.0)

### ⚠ BREAKING CHANGES

* **client:** use readonly types for properties

### Features

* add Foundry client ([5f87e12](https://github.com/anthropics/anthropic-sdk-csharp/commit/5f87e129a262d8a373e5e10bcca4196cf5db0394))
* **api:** add claude-opus-4-1-20250805 ([c38689c](https://github.com/anthropics/anthropic-sdk-csharp/commit/c38689ce56b61bd5259785cd0478c8cecdf01630))
* **api:** add support for Search Result Content Blocks ([3300718](https://github.com/anthropics/anthropic-sdk-csharp/commit/33007185312999c941e9ece33dde30b397e1b2ec))
* **api:** add support for structured outputs beta ([a809be6](https://github.com/anthropics/anthropic-sdk-csharp/commit/a809be6a3bddca622662670044c480ecdfec83eb))
* **api:** adds support for Claude Opus 4.5, Effort, Advanced Tool Use Features, Autocompaction, and Computer Use v5 ([144a820](https://github.com/anthropics/anthropic-sdk-csharp/commit/144a8209e522f5bba2174b1efd3d5607a2d7c145))
* **api:** adds support for Documents in tool results ([a7b5086](https://github.com/anthropics/anthropic-sdk-csharp/commit/a7b5086b8dd0211e723b4d6f9b903091df387d37))
* **api:** adds support for text_editor_20250728 tool ([159d728](https://github.com/anthropics/anthropic-sdk-csharp/commit/159d7280cc3347b2241833ec32e64ddd8d467fbf))
* **api:** adds support for web_fetch_20250910 tool ([1d12859](https://github.com/anthropics/anthropic-sdk-csharp/commit/1d128598434a110447606a22c69394f9e24262d5))
* **api:** makes 1 hour TTL Cache Control generally available ([84b1ad3](https://github.com/anthropics/anthropic-sdk-csharp/commit/84b1ad3530ecf8f6fdb3c6dcd12e9a6331add9b4))
* **api:** removed older deprecated models ([f5aafba](https://github.com/anthropics/anthropic-sdk-csharp/commit/f5aafbabd37dce4c3d14e3a8925bd9fde926bbd3))
* **api:** rename C# package to Anthropic ([83b024f](https://github.com/anthropics/anthropic-sdk-csharp/commit/83b024f68676a9a244650172ec46352814fe3669))
* **api:** search result content blocks ([e4368ee](https://github.com/anthropics/anthropic-sdk-csharp/commit/e4368ee1df5de9963ecd5295db7adaa2f882b776))
* **api:** update PHP and C# ([d63878a](https://github.com/anthropics/anthropic-sdk-csharp/commit/d63878a830159b05ad5262de680cbd3c1cd1dd99))
* **api:** update to desired NuGet name ([c4b6820](https://github.com/anthropics/anthropic-sdk-csharp/commit/c4b682000227c3daf1b6c854f7b4b3fe316aec45))
* **betas:** add context-1m-2025-08-07 ([f65802a](https://github.com/anthropics/anthropic-sdk-csharp/commit/f65802a33c9474d32774a4aabae84ff53403acf8))
* **ci:** add publishing flow for nuget ([487ac2e](https://github.com/anthropics/anthropic-sdk-csharp/commit/487ac2e31527626cf2105bb3209faa49ddb1654a))
* **client:** add implicit conversions to enums ([324f263](https://github.com/anthropics/anthropic-sdk-csharp/commit/324f263ccdee745b3f815abb17c09310146e56c0))
* **client:** add some convenience constructors ([e2541e1](https://github.com/anthropics/anthropic-sdk-csharp/commit/e2541e10315a9304f4925fdafffc2494ab62a20f))
* **client:** add streaming methods ([b394064](https://github.com/anthropics/anthropic-sdk-csharp/commit/b394064caef025f0a8cacfc299dc1dbe9636b1c8))
* **client:** add switch and match helpers for unions ([d44a80c](https://github.com/anthropics/anthropic-sdk-csharp/commit/d44a80c8872f1fca137fbbfb4ed41c178ebe3c35))
* **client:** add x-stainless-retry-count ([ad0fba4](https://github.com/anthropics/anthropic-sdk-csharp/commit/ad0fba4c807bed061f3a79d39d12572fd6668452))
* **client:** additional methods for positional params ([08c27c6](https://github.com/anthropics/anthropic-sdk-csharp/commit/08c27c6a4cb45b886be44babbb51bf4934add374))
* **client:** additional methods for positional params ([8bc6323](https://github.com/anthropics/anthropic-sdk-csharp/commit/8bc6323c38ce551f995bec5e4b1584460b7f037b))
* **client:** adds support for code-execution-2025-08-26 tool ([5be3c78](https://github.com/anthropics/anthropic-sdk-csharp/commit/5be3c787f331d2dcaae55f1ed900b6cc04052818))
* **client:** allow omitting all params object when all optional ([68a792f](https://github.com/anthropics/anthropic-sdk-csharp/commit/68a792f6591d02d8fce140949831a84b21eed686))
* **client:** automatically set constants for user ([bb1343e](https://github.com/anthropics/anthropic-sdk-csharp/commit/bb1343ef5311c535a0836e83c65e156483eb4a45))
* **client:** basic paginated endpoint support ([4766f1e](https://github.com/anthropics/anthropic-sdk-csharp/commit/4766f1ec369b01863ce96a22264f40d9f953f412))
* **client:** implement implicit union casts ([e36b8fa](https://github.com/anthropics/anthropic-sdk-csharp/commit/e36b8fa372c81c387298bd2e700a74a0dac2c8d1))
* **client:** improve csproj ([0874d78](https://github.com/anthropics/anthropic-sdk-csharp/commit/0874d78b4d9418277b0912f88f251154c5cef3e5))
* **client:** improve model names ([18a0af9](https://github.com/anthropics/anthropic-sdk-csharp/commit/18a0af9f5d5eca5e0b1267c213e35d748ca3a0a0))
* **client:** improve signature of `trypickx` methods ([620b39b](https://github.com/anthropics/anthropic-sdk-csharp/commit/620b39bd653c5c5fbdf3ddd0d8bfe3921ec9c81f))
* **client:** improve some names ([8d28ac4](https://github.com/anthropics/anthropic-sdk-csharp/commit/8d28ac49a9a77b1486607c4fd4ddcfb40a138a3c))
* **client:** make union deserialization more robust ([26d42da](https://github.com/anthropics/anthropic-sdk-csharp/commit/26d42dae0039f709e4ca33449c9567bbc0ff689b))
* **client:** make union deserialization more robust ([f85bc36](https://github.com/anthropics/anthropic-sdk-csharp/commit/f85bc367ad3f076d36b233cc956768fea226d1ae))
* **client:** shorten union variant names ([c397c9b](https://github.com/anthropics/anthropic-sdk-csharp/commit/c397c9bda8cfde000e9b092fb0f384695a9993cd))
* **internal:** allow overriding mock url via `TEST_API_BASE_URL` env ([f14a23c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f14a23c5b6065a377bf273189c5cf4d5b1826250))


### Bug Fixes

* **client:** better type names ([057bf2d](https://github.com/anthropics/anthropic-sdk-csharp/commit/057bf2ddf817d443f86fe5913cf5399705c65914))
* **client:** check response status when `MaxRetries = 0` ([6e568ec](https://github.com/anthropics/anthropic-sdk-csharp/commit/6e568ec525ca23e933660c6fec61fc81c27f9f7c))
* **client:** compilation error ([56d1c41](https://github.com/anthropics/anthropic-sdk-csharp/commit/56d1c41dbcca95ddbd40cb296ebe516a3598b30d))
* **client:** handle multiple auth options gracefully ([a5fdd62](https://github.com/anthropics/anthropic-sdk-csharp/commit/a5fdd6218b188cb45e9a10304edd40334261d272))
* **client:** handling of null value type ([eb6a775](https://github.com/anthropics/anthropic-sdk-csharp/commit/eb6a775164392f1a55bdfecee3ac402b5a0fdd0a))
* **client:** improve model validation ([b77753e](https://github.com/anthropics/anthropic-sdk-csharp/commit/b77753e46cad3eda6ef37f4ad2df2066199b1a14))
* **client:** return correct type for foundry#WithOptions ([#18](https://github.com/anthropics/anthropic-sdk-csharp/issues/18)) ([9ff2124](https://github.com/anthropics/anthropic-sdk-csharp/commit/9ff2124a9190269ff4a469b6e8c9f6b895f8d2d2))
* **client:** return correct type for foundry#WithOptions ([#18](https://github.com/anthropics/anthropic-sdk-csharp/issues/18)) ([f814a46](https://github.com/anthropics/anthropic-sdk-csharp/commit/f814a460503abf7fdf7a824b5bf446ef74d60f28))
* **client:** support non-optional client options ([fadaa63](https://github.com/anthropics/anthropic-sdk-csharp/commit/fadaa63599a9411094aede97aa59084916a3de6d))
* **client:** update custom code for readonly ([#198](https://github.com/anthropics/anthropic-sdk-csharp/issues/198)) ([e3c26f1](https://github.com/anthropics/anthropic-sdk-csharp/commit/e3c26f1fb586a8a4de5df1cd08618d73b36006f0))
* **client:** use readonly types for properties ([cd28fd5](https://github.com/anthropics/anthropic-sdk-csharp/commit/cd28fd566402011eed8f369bcc9173119cb1b262))
* **client:** with expressions for models ([b42ce94](https://github.com/anthropics/anthropic-sdk-csharp/commit/b42ce9405f04d3f830c2e4bfdeb9c433ba780222))
* **docs:** re-order using statements ([b77bdb2](https://github.com/anthropics/anthropic-sdk-csharp/commit/b77bdb2aa4bcde1a0e21938c1d4be5ea755dfaed))
* **internal:** don't format csproj files ([0b5c2c6](https://github.com/anthropics/anthropic-sdk-csharp/commit/0b5c2c660f8a2882034c6a96dd88ba7b2c98d6e8))
* **internal:** minor project fixes ([3c344e2](https://github.com/anthropics/anthropic-sdk-csharp/commit/3c344e2db929ed43cc49854c791ea10e5e42489c))
* **internal:** prefer to use implicit instantiation when possible ([b869753](https://github.com/anthropics/anthropic-sdk-csharp/commit/b86975337839d95e151e27421c84566ad0c6ecd7))
* **internal:** remove unused null class ([c46f844](https://github.com/anthropics/anthropic-sdk-csharp/commit/c46f844118f54ca85615794d420c8b4202761f27))
* **internal:** various minor code fixes ([136162a](https://github.com/anthropics/anthropic-sdk-csharp/commit/136162addc0812087d051e8e5844226f31eda895))
* remove bad preprocessor directive ([9420cfd](https://github.com/anthropics/anthropic-sdk-csharp/commit/9420cfd8cb741c0e5c79491e04ed4ea6df284f52))
* use correct header name ([c83471e](https://github.com/anthropics/anthropic-sdk-csharp/commit/c83471e37ec40cc70b5fccc5f125f731353699be))
* use correct version ([aeba41c](https://github.com/anthropics/anthropic-sdk-csharp/commit/aeba41c844ba58fe59a56090dd78fd794ad07a8b))
* use correct versions ([7c97d7f](https://github.com/anthropics/anthropic-sdk-csharp/commit/7c97d7f19c6937a2dacb666b05b9b9d040d677c7))
* use correct versions ([c78c8db](https://github.com/anthropics/anthropic-sdk-csharp/commit/c78c8db4b6effa6b1438bb879bcafdad2d155808))


### Performance Improvements

* **client:** use async deserialization in `HttpResponse` ([293020b](https://github.com/anthropics/anthropic-sdk-csharp/commit/293020b5e84414b751218f0c157ab49e9fb44980))


### Chores

* **api:** remove unsupported endpoints ([d318ba7](https://github.com/anthropics/anthropic-sdk-csharp/commit/d318ba7c3c652b813fe81316ac5d5110fd8ebcb2))
* **api:** update BetaCitationSearchResultLocation ([801a222](https://github.com/anthropics/anthropic-sdk-csharp/commit/801a222c8eeaa43625bdc078ef9da8ffec9351e4))
* **client:** add TextEditor_20250429 tool ([adee5b4](https://github.com/anthropics/anthropic-sdk-csharp/commit/adee5b42af4ac04e3569570aca45a931aa16dd6f))
* **client:** change name of underlying properties for models and params ([75a2cce](https://github.com/anthropics/anthropic-sdk-csharp/commit/75a2ccecefaf3fff5a07138a3c38ff0b9b9df476))
* **client:** deprecate some symbols ([08bfad9](https://github.com/anthropics/anthropic-sdk-csharp/commit/08bfad97735fda235d92655adae05be45d51eac0))
* **client:** improve union validation ([d86c38d](https://github.com/anthropics/anthropic-sdk-csharp/commit/d86c38d5ab783c07b67f95c581d44e644f48b0d2))
* **client:** make some interfaces internal ([476e69e](https://github.com/anthropics/anthropic-sdk-csharp/commit/476e69e077869ce56271dfe69837a02ea1d66811))
* **client:** swap `[@params](https://github.com/params)` to better name ([3d8e0d9](https://github.com/anthropics/anthropic-sdk-csharp/commit/3d8e0d96ba2e7e6d1c2aaf4da3848647bd6d5e1f))
* **client:** update namespace imports ([764df51](https://github.com/anthropics/anthropic-sdk-csharp/commit/764df5100097db98afeac71075e94eb84d4f5572))
* fix ci ([#196](https://github.com/anthropics/anthropic-sdk-csharp/issues/196)) ([8dede61](https://github.com/anthropics/anthropic-sdk-csharp/commit/8dede6176cb86e1ae85db9c8d0fae50c595ef964))
* **internal:** add logo to nuget package ([#181](https://github.com/anthropics/anthropic-sdk-csharp/issues/181)) ([e01f08d](https://github.com/anthropics/anthropic-sdk-csharp/commit/e01f08dbd35f05c3ecc964eb040312b4f7ca6713))
* **internal:** add tests for constants ([25b6f4f](https://github.com/anthropics/anthropic-sdk-csharp/commit/25b6f4f526fdc2b268ac850f2d73cdb5d39cb685))
* **internal:** clean up diffs vs codegen ([53b2d3c](https://github.com/anthropics/anthropic-sdk-csharp/commit/53b2d3cd5cc2d852deceba162f1482f0013af05b))
* **internal:** codegen related update ([fb6b738](https://github.com/anthropics/anthropic-sdk-csharp/commit/fb6b7383219e9fef56cdf0786170f1943249b9c7))
* **internal:** codegen related update ([135523a](https://github.com/anthropics/anthropic-sdk-csharp/commit/135523aad5f9df5ee22a25f4ba7670335f2b8647))
* **internal:** equality and more unit tests ([f270a7e](https://github.com/anthropics/anthropic-sdk-csharp/commit/f270a7ecbef5fb86d1193b48ae957ac1f3b4f563))
* **internal:** refactor tests to de-duplicate client instantiation logic ([f14a23c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f14a23c5b6065a377bf273189c5cf4d5b1826250))
* **internal:** remove redundant keyword ([72e07e7](https://github.com/anthropics/anthropic-sdk-csharp/commit/72e07e7e8de33aa73203afa64d91ec6860a98283))
* **internal:** remove unnecessary internal aliasing ([d210122](https://github.com/anthropics/anthropic-sdk-csharp/commit/d2101221fc498b57c60593896491751a6c77f9d8))
* **internal:** rename parameters ([0013847](https://github.com/anthropics/anthropic-sdk-csharp/commit/0013847d2d7db6f4611b6c863f74b11a442310a1))
* **internal:** stop running whitespace lint ([f14a23c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f14a23c5b6065a377bf273189c5cf4d5b1826250))
* **internal:** suppress diagnostic for .netstandard2.0 ([9ede62d](https://github.com/anthropics/anthropic-sdk-csharp/commit/9ede62de370abcad1fc1a5211700a6c967d360ca))
* **internal:** suppress diagnostic for .netstandard2.0 ([1b0714d](https://github.com/anthropics/anthropic-sdk-csharp/commit/1b0714dc78ba2e69ab149d7cf768963379ec73e5))
* **internal:** update csproj formatting ([6036c7f](https://github.com/anthropics/anthropic-sdk-csharp/commit/6036c7fa2683bc18299fa6d994b4cd117988d86a))
* **internal:** use nicer generic names ([00c3c7e](https://github.com/anthropics/anthropic-sdk-csharp/commit/00c3c7e215233ff0882930db8dc8177c22b85165))
* update formatting ([8b06f4f](https://github.com/anthropics/anthropic-sdk-csharp/commit/8b06f4f14153b608acbe1f00461a055e3c74d553))
* use non-aliased `using` ([ba9d1ac](https://github.com/anthropics/anthropic-sdk-csharp/commit/ba9d1ac2f5b3e86dc4fcf9f5857e550a40ec8995))


### Documentation

* add more comments ([8ade211](https://github.com/anthropics/anthropic-sdk-csharp/commit/8ade21175fb18a01e79a8393e49ee163c50e9e94))
* add more comments ([915d808](https://github.com/anthropics/anthropic-sdk-csharp/commit/915d80832dc1e11b212048081ce55255fe5b1024))
* **client:** add more property comments ([a3e973b](https://github.com/anthropics/anthropic-sdk-csharp/commit/a3e973b0e6d057e58e6f0bd08c8a5635da896974))
* **internal:** add warning about implementing interface ([2171969](https://github.com/anthropics/anthropic-sdk-csharp/commit/217196968fa67df4ef967333c1e0ed423d4fe1e6))


### Refactors

* **client:** make unknown variants implicit ([7b966ab](https://github.com/anthropics/anthropic-sdk-csharp/commit/7b966ab3dbfd1d41998fb0ab71f8f1ae9e0d625a))
* **client:** make unknown variants implicit ([eb0e5b6](https://github.com/anthropics/anthropic-sdk-csharp/commit/eb0e5b628d7090adc34300775043ecd26ccfffaf))
* **client:** refine enum representation ([a3e973b](https://github.com/anthropics/anthropic-sdk-csharp/commit/a3e973b0e6d057e58e6f0bd08c8a5635da896974))
* **client:** use `System.Net.ServerSentEvents` ([b733f32](https://github.com/anthropics/anthropic-sdk-csharp/commit/b733f32912e9b5a0ff1bd90c9a56de8ba14950a2))
* **client:** use plural for service namespace ([843da53](https://github.com/anthropics/anthropic-sdk-csharp/commit/843da53c91a4e925298aae8907f8990b7e13de9e))
* **internal:** remove abstract static methods ([a1e13bb](https://github.com/anthropics/anthropic-sdk-csharp/commit/a1e13bbf38dfa84858fe31e9418d80fe1284bebb))
* **internal:** share get/set logic ([eb6a775](https://github.com/anthropics/anthropic-sdk-csharp/commit/eb6a775164392f1a55bdfecee3ac402b5a0fdd0a))

## 11.0.0 (2025-12-01)

Full Changelog: [v10.4.0...v11.0.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.4.0...v11.0.0)

### ⚠ BREAKING CHANGES

* **client:** use readonly types for properties

### Features

* **client:** improve csproj ([f9e5956](https://github.com/anthropics/anthropic-sdk-csharp/commit/f9e5956ba1f2ef3942f837a916c58c293dd933e8))


### Bug Fixes

* **client:** update custom code for readonly ([#198](https://github.com/anthropics/anthropic-sdk-csharp/issues/198)) ([11cdfa4](https://github.com/anthropics/anthropic-sdk-csharp/commit/11cdfa4f1e626fbbeccccea2ef8152665a70cabf))
* **client:** use readonly types for properties ([1d78f38](https://github.com/anthropics/anthropic-sdk-csharp/commit/1d78f38be82098a5f27fbd7f32b7a89fae3de844))
* **internal:** running net462 tests on ci ([23ca28a](https://github.com/anthropics/anthropic-sdk-csharp/commit/23ca28ab7f8b640e16aa08a164522c6122ecf1dc))
* release please config for foundry ([#52](https://github.com/anthropics/anthropic-sdk-csharp/issues/52)) ([45d4b76](https://github.com/anthropics/anthropic-sdk-csharp/commit/45d4b76048b9b5a574cf39cbb2b921e9db1277e1))


### Performance Improvements

* **client:** use async deserialization in `HttpResponse` ([1ce5af7](https://github.com/anthropics/anthropic-sdk-csharp/commit/1ce5af76ffbb7742c796240877f79f91ffdb49fb))


### Chores

* **client:** update namespace imports ([9d89414](https://github.com/anthropics/anthropic-sdk-csharp/commit/9d89414d410ada2667c6c1760877a6c862f7e9c5))
* fix ci ([#196](https://github.com/anthropics/anthropic-sdk-csharp/issues/196)) ([98beb5b](https://github.com/anthropics/anthropic-sdk-csharp/commit/98beb5bb6374969c9ccd40ff8553888bcb399fdf))
* **internal:** clean up diffs vs codegen ([ba8adc6](https://github.com/anthropics/anthropic-sdk-csharp/commit/ba8adc6ff59b060ad5c13d14fb5518b83564fee7))
* **internal:** fix release please config ([2732101](https://github.com/anthropics/anthropic-sdk-csharp/commit/27321011bea2ac4e3fbb591d4e81021e09469699))
* **internal:** set up cron release job ([2d1499c](https://github.com/anthropics/anthropic-sdk-csharp/commit/2d1499c142f635791ece0b62bd4d2827933d2d4d))
* **internal:** suppress diagnostic for .netstandard2.0 ([e781b24](https://github.com/anthropics/anthropic-sdk-csharp/commit/e781b24eaffd66d2a42b5994728fa09064b4314e))
* sync with release-please ([6c74dff](https://github.com/anthropics/anthropic-sdk-csharp/commit/6c74dff7c2c11aeac75ccb58f73fa06d9b380912))
* sync with release-please ([c0845ae](https://github.com/anthropics/anthropic-sdk-csharp/commit/c0845ae273c871b27ca9379392432a0bb37dc617))


### Documentation

* add more comments ([d4c4825](https://github.com/anthropics/anthropic-sdk-csharp/commit/d4c48257d26d2d394d5c15e475fe4875d42640e2))
* correct reqs ([0c67249](https://github.com/anthropics/anthropic-sdk-csharp/commit/0c672493b1c821d86fbcc31c06656eda4cdf739f))

## 10.4.0 (2025-11-25)

Full Changelog: [v10.3.0...v10.4.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.3.0...v10.4.0)

### Features

* **client:** support .NET Standard 2.0 ([70928cd](https://github.com/anthropics/anthropic-sdk-csharp/commit/70928cdd02452b2b7ad37f419b43d92680e02f9d))


### Bug Fixes

* **internal:** don't format csproj files ([76affbf](https://github.com/anthropics/anthropic-sdk-csharp/commit/76affbf85b3f9c04bd500020644660265d361fb6))


### Chores

* **internal:** add logo to nuget package ([#181](https://github.com/anthropics/anthropic-sdk-csharp/issues/181)) ([f2ca130](https://github.com/anthropics/anthropic-sdk-csharp/commit/f2ca130ab65ec6db6ce164a33a7a820de5187e1a))
* **internal:** remove redundant keyword ([f33f185](https://github.com/anthropics/anthropic-sdk-csharp/commit/f33f185da453cc9c8293891cb653964d085e362e))
* remove .keep ([#37](https://github.com/anthropics/anthropic-sdk-csharp/issues/37)) ([3974964](https://github.com/anthropics/anthropic-sdk-csharp/commit/3974964dbf738d0a265f77482e3c9fecefdc5f67))


### Refactors

* **internal:** remove abstract static methods ([3a3dffe](https://github.com/anthropics/anthropic-sdk-csharp/commit/3a3dffedbc11260c1b5e65606671f9898af9531b))

## 10.3.0 (2025-11-24)

Full Changelog: [v10.2.1...v10.3.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.2.1...v10.3.0)

### Features

* **api:** adds support for Claude Opus 4.5, Effort, Advance Tool Use Features, Autocompaction, and Computer Use v5 ([144a820](https://github.com/anthropics/anthropic-sdk-csharp/commit/144a8209e522f5bba2174b1efd3d5607a2d7c145))


### Bug Fixes

* **internal:** install csharpier during ci lint phase ([8898df9](https://github.com/anthropics/anthropic-sdk-csharp/commit/8898df9bf709867ddf3851bd5f5c0acbd8d90764))
* **internal:** minor project fixes ([3c344e2](https://github.com/anthropics/anthropic-sdk-csharp/commit/3c344e2db929ed43cc49854c791ea10e5e42489c))
* **internal:** remove release notes from foundry readme ([afeaa2f](https://github.com/anthropics/anthropic-sdk-csharp/commit/afeaa2f526c3818c244bb351b4dad56a59883395))


### Chores

* **client:** change name of underlying properties for models and params ([75a2cce](https://github.com/anthropics/anthropic-sdk-csharp/commit/75a2ccecefaf3fff5a07138a3c38ff0b9b9df476))
* formatting ([6850900](https://github.com/anthropics/anthropic-sdk-csharp/commit/6850900ae2b8f5da55381988af5d4cb5b2ee4351))
* **internal:** update release please config ([980d7fd](https://github.com/anthropics/anthropic-sdk-csharp/commit/980d7fd21375f9125c0bd0f58a378a081bfa11bb))

## 10.2.1 (2025-11-20)

Full Changelog: [v10.2.0...v10.2.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.2.0...v10.2.1)

## 10.2.0 (2025-11-20)

Full Changelog: [v10.1.2...v10.2.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.1.2...v10.2.0)

### Features

* **client:** additional methods for positional params ([8bc6323](https://github.com/anthropics/anthropic-sdk-csharp/commit/8bc6323c38ce551f995bec5e4b1584460b7f037b))


### Bug Fixes

* **client:** return correct type for foundry#WithOptions ([#18](https://github.com/anthropics/anthropic-sdk-csharp/issues/18)) ([f814a46](https://github.com/anthropics/anthropic-sdk-csharp/commit/f814a460503abf7fdf7a824b5bf446ef74d60f28))
* use correct versions ([c78c8db](https://github.com/anthropics/anthropic-sdk-csharp/commit/c78c8db4b6effa6b1438bb879bcafdad2d155808))


### Refactors

* **client:** make unknown variants implicit ([eb0e5b6](https://github.com/anthropics/anthropic-sdk-csharp/commit/eb0e5b628d7090adc34300775043ecd26ccfffaf))

## 10.1.2 (2025-11-18)

Full Changelog: [v10.1.1...v10.1.2](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.1.1...v10.1.2)

### Bug Fixes

* use correct version ([a808311](https://github.com/anthropics/anthropic-sdk-csharp/commit/a8083119584c82ec26e1d74f980b6c021e1fbb10))

## 10.1.1 (2025-11-18)

Full Changelog: [v10.1.0...v10.1.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.1.0...v10.1.1)

## 10.1.0 (2025-11-18)

Full Changelog: [v10.0.1...v10.1.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/v10.0.1...v10.1.0)

### Features

* add Foundry client ([8ddea23](https://github.com/anthropics/anthropic-sdk-csharp/commit/8ddea2363a799b366740779703f074fbe8dadf56))

## 10.0.1 (2025-11-18)

Full Changelog: [v0.2.0...v10.0.1](https://github.com/anthropics/anthropic-sdk-csharp/compare/v0.2.0...v10.0.1)

### ⚠ BREAKING CHANGES

* **client:** improve names of some types
* **client:** use `DateTimeOffset` instead of `DateTime`
* **client:** flatten service namespaces
* **client:** interpret null as omitted in some properties

### Features

* **api:** add file download method ([a03d526](https://github.com/anthropics/anthropic-sdk-csharp/commit/a03d5267282ba893e96ca96c70c7b28326076d1a))
* **api:** add support for structured outputs beta ([17ea9b3](https://github.com/anthropics/anthropic-sdk-csharp/commit/17ea9b388f10cfe621af9aeb9f3ddd799027fc09))
* **api:** rename C# package to Anthropic ([2ba3485](https://github.com/anthropics/anthropic-sdk-csharp/commit/2ba34850dcd783b672aff1371970db7e5f0abc14))
* **client:** add `HttpResponse.ReadAsStream` method ([677857b](https://github.com/anthropics/anthropic-sdk-csharp/commit/677857b53e4bcfbc3f6a7b0d3cd7e2c9af86c9cd))
* **client:** add cancellation token support ([bf4c0e5](https://github.com/anthropics/anthropic-sdk-csharp/commit/bf4c0e57952376844c27f63311e70cb903c5897c))
* **client:** add per-resource headers ([1d7658a](https://github.com/anthropics/anthropic-sdk-csharp/commit/1d7658ad37ade9ed4d5a73521f72cb3a389535de))
* **client:** add retries support ([3327c9b](https://github.com/anthropics/anthropic-sdk-csharp/commit/3327c9b2fd704a2807a9d4453d1c99c7f12e97f9))
* **client:** add some implicit operators ([bf26da8](https://github.com/anthropics/anthropic-sdk-csharp/commit/bf26da89cad05f586a7f24fbcf0ad5adcfefc44f))
* **client:** send `User-Agent` header ([e8a0844](https://github.com/anthropics/anthropic-sdk-csharp/commit/e8a08449899460d22522336714d86264755e1a57))
* **client:** send `X-Stainless-Arch` header ([d66d180](https://github.com/anthropics/anthropic-sdk-csharp/commit/d66d180ff7c04aff7ec53cfefaa1dff0236ce53c))
* **client:** send `X-Stainless-Lang` and `X-Stainless-OS` headers ([bcc30e9](https://github.com/anthropics/anthropic-sdk-csharp/commit/bcc30e9a754798c96d28516d556e40c4e8cbf802))
* **client:** send `X-Stainless-Package-Version` headers ([84bf583](https://github.com/anthropics/anthropic-sdk-csharp/commit/84bf583218f56682972add2c77784c88700eff53))
* **client:** send `X-Stainless-Runtime` and `X-Stainless-Runtime-Version` ([94d2581](https://github.com/anthropics/anthropic-sdk-csharp/commit/94d25812e111657e81e9f7c27dfdab97c0af82f4))
* **client:** send `X-Stainless-Timeout` header ([95ec578](https://github.com/anthropics/anthropic-sdk-csharp/commit/95ec578685f65b8ff008b35b4cf43f289107dc86))
* **client:** validate constant values ([493a9ef](https://github.com/anthropics/anthropic-sdk-csharp/commit/493a9efb26479cf26e21d7c7c95b70507c0d3dc9))
* **csharp:** enable nuget publishing ([4a4a1bc](https://github.com/anthropics/anthropic-sdk-csharp/commit/4a4a1bccd369b7f7b38db636c2f5846c43b7d826))
* **docs:** add package/version notice ([76b74eb](https://github.com/anthropics/anthropic-sdk-csharp/commit/76b74eb7f1aaee9ba6cb1844b061aee8c1288633))
* **docs:** Semver warning ([55c20ba](https://github.com/anthropics/anthropic-sdk-csharp/commit/55c20bad38b05b7a2ec166ca403214833103b9c1))
* **docs:** tweak readme notice ([82d5990](https://github.com/anthropics/anthropic-sdk-csharp/commit/82d5990cb33ba6acc55d12954c94aafaa75b7f7d))
* **docs:** Update README for nuget (instead of just github) ([6bde0b4](https://github.com/anthropics/anthropic-sdk-csharp/commit/6bde0b45452e1ecde305ebace0b8a063ac205e40))
* **docs:** Update version refs in README ([70d787d](https://github.com/anthropics/anthropic-sdk-csharp/commit/70d787dcc7d47a79e47814209f81a1366a3460c7))


### Bug Fixes

* **client:** interpret null as omitted in some properties ([56059db](https://github.com/anthropics/anthropic-sdk-csharp/commit/56059db7047e7263cbd666f19293985577f8339d))
* **client:** use `DateTimeOffset` instead of `DateTime` ([dbc7f6f](https://github.com/anthropics/anthropic-sdk-csharp/commit/dbc7f6f086dd0a75d869c1c683fa3c245c18f548))
* use correct header name ([f6d0942](https://github.com/anthropics/anthropic-sdk-csharp/commit/f6d0942657fd87bc7b479602e1e913f404da0bb7))


### Performance Improvements

* **client:** optimize header creation ([3d37bb5](https://github.com/anthropics/anthropic-sdk-csharp/commit/3d37bb54241981dfbfdfc7a8f69c2430de808bfb))


### Chores

* **client:** deprecate some symbols ([b3446f6](https://github.com/anthropics/anthropic-sdk-csharp/commit/b3446f6d62f8d6e53a6871aee5979903f6b04498))
* **internal:** add prism log file to gitignore ([8588901](https://github.com/anthropics/anthropic-sdk-csharp/commit/8588901ed4a32880165b344246bc3b8c1dc2464d))
* **internal:** codegen related update ([cf3f5d5](https://github.com/anthropics/anthropic-sdk-csharp/commit/cf3f5d5f9af0f066c53c2dcb0d27bed5f602edce))
* **internal:** delete empty test files ([a79abd1](https://github.com/anthropics/anthropic-sdk-csharp/commit/a79abd17f32d1313f77365faf0fed8d004ff48c3))
* **internal:** improve devcontainer ([ab246ff](https://github.com/anthropics/anthropic-sdk-csharp/commit/ab246ffcde051808c017d73c46d18a769ec7d2c0))
* **internal:** minor improvements to csproj and gitignore ([bf94b8c](https://github.com/anthropics/anthropic-sdk-csharp/commit/bf94b8c15a7f296780660134ceb251e28ee0ed23))
* **internal:** reduce import qualification ([137c8b4](https://github.com/anthropics/anthropic-sdk-csharp/commit/137c8b4b2103d5b510698629359e7ef2a28512ad))
* **internal:** update release please config ([bd94183](https://github.com/anthropics/anthropic-sdk-csharp/commit/bd9418322fe76a3c7db57375ddb2f0ba8ee49543))


### Documentation

* **client:** document max retries ([e1f611f](https://github.com/anthropics/anthropic-sdk-csharp/commit/e1f611fdd28e19788f0fe843396707d20bb069fa))
* **client:** separate comment content into paragraphs ([1f89605](https://github.com/anthropics/anthropic-sdk-csharp/commit/1f89605692d5cfee120c740098f0a35ccded6d93))
* **internal:** add warning about implementing interface ([5476caf](https://github.com/anthropics/anthropic-sdk-csharp/commit/5476cafac1904b8185fecd56ebbe088136df3ccd))


### Refactors

* **client:** flatten service namespaces ([8de3f66](https://github.com/anthropics/anthropic-sdk-csharp/commit/8de3f666532cf1ed31031587c4819e024e3bfb6f))
* **client:** improve names of some types ([2e52d59](https://github.com/anthropics/anthropic-sdk-csharp/commit/2e52d5996dd0121814b2827eafa3a6fca6f5c3d9))
* **client:** move some defaults out of `ClientOptions` ([d536293](https://github.com/anthropics/anthropic-sdk-csharp/commit/d536293d0cc42d3341437f390587907cc4a8df5e))
* **client:** pass around `ClientOptions` instead of client ([608310d](https://github.com/anthropics/anthropic-sdk-csharp/commit/608310d02a14ccfdaefad3c0f8d921ed98c2375e))

## 0.2.0 (2025-11-05)

Full Changelog: [v0.1.0...v0.2.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/v0.1.0...v0.2.0)

### ⚠ BREAKING CHANGES

* **client:** make models immutable

### Features

* **api:** add ability to clear thinking in context management ([05d2ce6](https://github.com/anthropics/anthropic-sdk-csharp/commit/05d2ce6bc64fe547fe7bc695d383af89caf7a45d))
* **client:** add response validation option ([6130f1b](https://github.com/anthropics/anthropic-sdk-csharp/commit/6130f1bc759bcc6c54cac411f69dd237c7fb40ce))
* **client:** add support for option modification ([e105fba](https://github.com/anthropics/anthropic-sdk-csharp/commit/e105fbad5f26c737c57ce23ad2cbcd81b89bd07e))
* **client:** make models immutable ([f55629c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f55629c40cf51fc43cf3a64ec87e53051f88fee6))
* **client:** support request timeout ([7411046](https://github.com/anthropics/anthropic-sdk-csharp/commit/7411046b4bc02671bd805d96a6c2745df0af4fcc))


### Chores

* **api:** mark older sonnet models as deprecated ([fc00d2b](https://github.com/anthropics/anthropic-sdk-csharp/commit/fc00d2b1dd5f100e523acf6f440e7a32c2452576))
* **client:** simplify field validations ([6130f1b](https://github.com/anthropics/anthropic-sdk-csharp/commit/6130f1bc759bcc6c54cac411f69dd237c7fb40ce))
* **internal:** codegen related update ([2798e0a](https://github.com/anthropics/anthropic-sdk-csharp/commit/2798e0a5fdc81a6076d449a73e8e880eb451b500))
* **internal:** extract `ClientOptions` struct ([7e906c8](https://github.com/anthropics/anthropic-sdk-csharp/commit/7e906c854b0b68e981565df411407039dc6486e9))
* **internal:** full qualify some references ([8a52868](https://github.com/anthropics/anthropic-sdk-csharp/commit/8a528685fbb605a06427773868638ebdcecb97b6))


### Documentation

* **client:** document `WithOptions` ([38352b0](https://github.com/anthropics/anthropic-sdk-csharp/commit/38352b0ec8b3b1d1f98ef08e83437875440cb9ba))
* **client:** document response validation ([0e9f728](https://github.com/anthropics/anthropic-sdk-csharp/commit/0e9f72869c1c85f3e116c17eae5422847e2615fb))
* **client:** document timeout option ([80d8d7f](https://github.com/anthropics/anthropic-sdk-csharp/commit/80d8d7fa0f2251892ee6c17e99c9a8db04334321))
* **client:** improve snippet formatting ([94dc213](https://github.com/anthropics/anthropic-sdk-csharp/commit/94dc21334c5caeb106f5d07971c92c8b4a45aa1a))

## 0.1.0 (2025-10-27)

Full Changelog: [v0.0.1...v0.1.0](https://github.com/anthropics/anthropic-sdk-csharp/compare/v0.0.1...v0.1.0)

### Features

* **api:** add claude-opus-4-1-20250805 ([c38689c](https://github.com/anthropics/anthropic-sdk-csharp/commit/c38689ce56b61bd5259785cd0478c8cecdf01630))
* **api:** add support for Search Result Content Blocks ([3300718](https://github.com/anthropics/anthropic-sdk-csharp/commit/33007185312999c941e9ece33dde30b397e1b2ec))
* **api:** adding support for agent skills ([4acc546](https://github.com/anthropics/anthropic-sdk-csharp/commit/4acc546f3d2117c098bf5eada070a83e619dbe5f))
* **api:** adds support for Claude Sonnet 4.5 and context management features ([bab904c](https://github.com/anthropics/anthropic-sdk-csharp/commit/bab904c771612cde421696bda8616819024e863e))
* **api:** adds support for Documents in tool results ([a7b5086](https://github.com/anthropics/anthropic-sdk-csharp/commit/a7b5086b8dd0211e723b4d6f9b903091df387d37))
* **api:** adds support for text_editor_20250728 tool ([159d728](https://github.com/anthropics/anthropic-sdk-csharp/commit/159d7280cc3347b2241833ec32e64ddd8d467fbf))
* **api:** adds support for web_fetch_20250910 tool ([74a7a92](https://github.com/anthropics/anthropic-sdk-csharp/commit/74a7a923abf5eef3ba34d6b2dda23a0e038d1064))
* **api:** makes 1 hour TTL Cache Control generally available ([84b1ad3](https://github.com/anthropics/anthropic-sdk-csharp/commit/84b1ad3530ecf8f6fdb3c6dcd12e9a6331add9b4))
* **api:** manual updates ([1528d71](https://github.com/anthropics/anthropic-sdk-csharp/commit/1528d714aee94bec3e0218e3f12d207fb5178878))
* **api:** removed older deprecated models ([f5aafba](https://github.com/anthropics/anthropic-sdk-csharp/commit/f5aafbabd37dce4c3d14e3a8925bd9fde926bbd3))
* **api:** search result content blocks ([e4368ee](https://github.com/anthropics/anthropic-sdk-csharp/commit/e4368ee1df5de9963ecd5295db7adaa2f882b776))
* **api:** update PHP and C# ([d63878a](https://github.com/anthropics/anthropic-sdk-csharp/commit/d63878a830159b05ad5262de680cbd3c1cd1dd99))
* **api:** update to desired NuGet name ([c4b6820](https://github.com/anthropics/anthropic-sdk-csharp/commit/c4b682000227c3daf1b6c854f7b4b3fe316aec45))
* **betas:** add context-1m-2025-08-07 ([f65802a](https://github.com/anthropics/anthropic-sdk-csharp/commit/f65802a33c9474d32774a4aabae84ff53403acf8))
* **ci:** add publishing flow for nuget ([487ac2e](https://github.com/anthropics/anthropic-sdk-csharp/commit/487ac2e31527626cf2105bb3209faa49ddb1654a))
* **ci:** implement test/lint ci ([b34d54a](https://github.com/anthropics/anthropic-sdk-csharp/commit/b34d54ab994e80cb9a57721bfef817f857b4a0b9))
* **client:** add and set all client ops ([3dee455](https://github.com/anthropics/anthropic-sdk-csharp/commit/3dee45538cd1f65cfa6da729ab9c3e6b47dafab7))
* **client:** add implicit conversions to enums ([324f263](https://github.com/anthropics/anthropic-sdk-csharp/commit/324f263ccdee745b3f815abb17c09310146e56c0))
* **client:** add some convenience constructors ([e2541e1](https://github.com/anthropics/anthropic-sdk-csharp/commit/e2541e10315a9304f4925fdafffc2494ab62a20f))
* **client:** add streaming methods ([b394064](https://github.com/anthropics/anthropic-sdk-csharp/commit/b394064caef025f0a8cacfc299dc1dbe9636b1c8))
* **client:** add switch and match helpers for unions ([d44a80c](https://github.com/anthropics/anthropic-sdk-csharp/commit/d44a80c8872f1fca137fbbfb4ed41c178ebe3c35))
* **client:** adds support for code-execution-2025-08-26 tool ([5be3c78](https://github.com/anthropics/anthropic-sdk-csharp/commit/5be3c787f331d2dcaae55f1ed900b6cc04052818))
* **client:** allow omitting all params object when all optional ([68a792f](https://github.com/anthropics/anthropic-sdk-csharp/commit/68a792f6591d02d8fce140949831a84b21eed686))
* **client:** automatically set constants for user ([bb1343e](https://github.com/anthropics/anthropic-sdk-csharp/commit/bb1343ef5311c535a0836e83c65e156483eb4a45))
* **client:** basic paginated endpoint support ([4766f1e](https://github.com/anthropics/anthropic-sdk-csharp/commit/4766f1ec369b01863ce96a22264f40d9f953f412))
* **client:** implement implicit union casts ([e36b8fa](https://github.com/anthropics/anthropic-sdk-csharp/commit/e36b8fa372c81c387298bd2e700a74a0dac2c8d1))
* **client:** improve model names ([18a0af9](https://github.com/anthropics/anthropic-sdk-csharp/commit/18a0af9f5d5eca5e0b1267c213e35d748ca3a0a0))
* **client:** improve signature of `trypickx` methods ([620b39b](https://github.com/anthropics/anthropic-sdk-csharp/commit/620b39bd653c5c5fbdf3ddd0d8bfe3921ec9c81f))
* **client:** make union deserialization more robust ([26d42da](https://github.com/anthropics/anthropic-sdk-csharp/commit/26d42dae0039f709e4ca33449c9567bbc0ff689b))
* **client:** make union deserialization more robust ([f85bc36](https://github.com/anthropics/anthropic-sdk-csharp/commit/f85bc367ad3f076d36b233cc956768fea226d1ae))
* **client:** refactor exceptions ([e5cfd36](https://github.com/anthropics/anthropic-sdk-csharp/commit/e5cfd364afd96ce37f01a639a6587e7c27801715))
* **client:** refactor unions ([f6b60e3](https://github.com/anthropics/anthropic-sdk-csharp/commit/f6b60e3e4ce82b5442d27989f751c86de0354fc2))
* **client:** shorten union variant names ([c397c9b](https://github.com/anthropics/anthropic-sdk-csharp/commit/c397c9bda8cfde000e9b092fb0f384695a9993cd))
* **internal:** add dedicated build job in ci ([9d46238](https://github.com/anthropics/anthropic-sdk-csharp/commit/9d46238a5bfc3c25276ed63bcc55b26aa42674d7))
* **internal:** add dev container ([e7682c0](https://github.com/anthropics/anthropic-sdk-csharp/commit/e7682c0790e1adbe4b24c9c6cadfb2c6c7c43112))
* **internal:** allow overriding mock url via `TEST_API_BASE_URL` env ([f14a23c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f14a23c5b6065a377bf273189c5cf4d5b1826250))
* **internal:** generate release flow files ([7a759d7](https://github.com/anthropics/anthropic-sdk-csharp/commit/7a759d76d63bd673defaa8a00aeb9c1111ce20a4))


### Bug Fixes

* **client:** better type names ([057bf2d](https://github.com/anthropics/anthropic-sdk-csharp/commit/057bf2ddf817d443f86fe5913cf5399705c65914))
* **client:** compilation error ([56d1c41](https://github.com/anthropics/anthropic-sdk-csharp/commit/56d1c41dbcca95ddbd40cb296ebe516a3598b30d))
* **client:** handle multiple auth options gracefully ([beabac5](https://github.com/anthropics/anthropic-sdk-csharp/commit/beabac5836af2a6bb946605d978cdc1325912aba))
* **client:** improve model validation ([b77753e](https://github.com/anthropics/anthropic-sdk-csharp/commit/b77753e46cad3eda6ef37f4ad2df2066199b1a14))
* **client:** instantiate union variant from list properly ([0db37e5](https://github.com/anthropics/anthropic-sdk-csharp/commit/0db37e5874d4a361048feac13014f25740e5142a))
* **client:** support non-optional client options ([fadaa63](https://github.com/anthropics/anthropic-sdk-csharp/commit/fadaa63599a9411094aede97aa59084916a3de6d))
* **docs:** re-order using statements ([b77bdb2](https://github.com/anthropics/anthropic-sdk-csharp/commit/b77bdb2aa4bcde1a0e21938c1d4be5ea755dfaed))
* **internal:** add message to sse exception ([8481832](https://github.com/anthropics/anthropic-sdk-csharp/commit/8481832fd8861b4f1ec9ed46389716ce0be4589c))
* **internal:** minor bug fixes on model instantiation and union validation ([6d0f0d9](https://github.com/anthropics/anthropic-sdk-csharp/commit/6d0f0d9b399fb1e270f215d130e9e59b37bec627))
* **internal:** prefer to use implicit instantiation when possible ([b869753](https://github.com/anthropics/anthropic-sdk-csharp/commit/b86975337839d95e151e27421c84566ad0c6ecd7))
* **internal:** remove example csproj ([e6e2c93](https://github.com/anthropics/anthropic-sdk-csharp/commit/e6e2c932f4ac99d7dacef0fad4177f0d0d76c9f2))
* **internal:** remove unused null class ([c46f844](https://github.com/anthropics/anthropic-sdk-csharp/commit/c46f844118f54ca85615794d420c8b4202761f27))
* **internal:** rename package directory ([a2557ac](https://github.com/anthropics/anthropic-sdk-csharp/commit/a2557ac8a9567267147d2d4f296c674f74460b82))
* **internal:** various minor code fixes ([136162a](https://github.com/anthropics/anthropic-sdk-csharp/commit/136162addc0812087d051e8e5844226f31eda895))


### Chores

* **api:** remove unsupported endpoints ([d318ba7](https://github.com/anthropics/anthropic-sdk-csharp/commit/d318ba7c3c652b813fe81316ac5d5110fd8ebcb2))
* **api:** update BetaCitationSearchResultLocation ([801a222](https://github.com/anthropics/anthropic-sdk-csharp/commit/801a222c8eeaa43625bdc078ef9da8ffec9351e4))
* **client:** add context-management-2025-06-27 beta header ([c716a85](https://github.com/anthropics/anthropic-sdk-csharp/commit/c716a85034072a14e1c189ca2422f6ec5fce680b))
* **client:** add model-context-window-exceeded-2025-08-26 beta header ([6ea4ac3](https://github.com/anthropics/anthropic-sdk-csharp/commit/6ea4ac36590316c30a7622f1cf67ce5dd473ed7e))
* **client:** add TextEditor_20250429 tool ([adee5b4](https://github.com/anthropics/anthropic-sdk-csharp/commit/adee5b42af4ac04e3569570aca45a931aa16dd6f))
* **client:** make some interfaces internal ([476e69e](https://github.com/anthropics/anthropic-sdk-csharp/commit/476e69e077869ce56271dfe69837a02ea1d66811))
* **client:** swap `[@params](https://github.com/params)` to better name ([3d8e0d9](https://github.com/anthropics/anthropic-sdk-csharp/commit/3d8e0d96ba2e7e6d1c2aaf4da3848647bd6d5e1f))
* **docs:** clarify beta library limitations in readme ([0aafa74](https://github.com/anthropics/anthropic-sdk-csharp/commit/0aafa74d0d8d2e4664033eacb248688aab52247b))
* improve example values ([7b3bc97](https://github.com/anthropics/anthropic-sdk-csharp/commit/7b3bc9703a5d189f5a7b41a96e91efb5463e0e8e))
* **internal:** codegen related update ([b98acb4](https://github.com/anthropics/anthropic-sdk-csharp/commit/b98acb42e3fe9bae70c6a799e48f914019e003b1))
* **internal:** codegen related update ([c765e20](https://github.com/anthropics/anthropic-sdk-csharp/commit/c765e20eada019988d7d13597258f5eff28431e8))
* **internal:** codegen related update ([fb6b738](https://github.com/anthropics/anthropic-sdk-csharp/commit/fb6b7383219e9fef56cdf0786170f1943249b9c7))
* **internal:** codegen related update ([135523a](https://github.com/anthropics/anthropic-sdk-csharp/commit/135523aad5f9df5ee22a25f4ba7670335f2b8647))
* **internal:** fix tests ([c7205c2](https://github.com/anthropics/anthropic-sdk-csharp/commit/c7205c25c86ce6f61d49a97d24827c21853f4d19))
* **internal:** refactor tests to de-duplicate client instantiation logic ([f14a23c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f14a23c5b6065a377bf273189c5cf4d5b1826250))
* **internal:** remove unnecessary internal aliasing ([d210122](https://github.com/anthropics/anthropic-sdk-csharp/commit/d2101221fc498b57c60593896491751a6c77f9d8))
* **internal:** rename parameters ([0013847](https://github.com/anthropics/anthropic-sdk-csharp/commit/0013847d2d7db6f4611b6c863f74b11a442310a1))
* **internal:** restructure some imports ([974e4a3](https://github.com/anthropics/anthropic-sdk-csharp/commit/974e4a31bde9f9e64e8115fd0198baa4342603c7))
* **internal:** stop running whitespace lint ([f14a23c](https://github.com/anthropics/anthropic-sdk-csharp/commit/f14a23c5b6065a377bf273189c5cf4d5b1826250))
* **internal:** update comment in script ([d9ff761](https://github.com/anthropics/anthropic-sdk-csharp/commit/d9ff7619e8a211f948913945e3f3d2b94a122611))
* **internal:** update test skipping reason ([124aab3](https://github.com/anthropics/anthropic-sdk-csharp/commit/124aab31ade145f7e326483f6ffc4aeda8005fe1))
* **internal:** use nicer generic names ([00c3c7e](https://github.com/anthropics/anthropic-sdk-csharp/commit/00c3c7e215233ff0882930db8dc8177c22b85165))
* rename some things ([654eb75](https://github.com/anthropics/anthropic-sdk-csharp/commit/654eb75cd6097c1554d07e2ec81da2c212e395be))
* update @stainless-api/prism-cli to v5.15.0 ([3a1d8f7](https://github.com/anthropics/anthropic-sdk-csharp/commit/3a1d8f7920630ca2111f401d0c4792ba324135ff))
* update formatting ([8b06f4f](https://github.com/anthropics/anthropic-sdk-csharp/commit/8b06f4f14153b608acbe1f00461a055e3c74d553))
* update SDK settings ([f5e0568](https://github.com/anthropics/anthropic-sdk-csharp/commit/f5e05681a49e4de0d8cc3f73e08d9590997c27a6))
* use non-aliased `using` ([ba9d1ac](https://github.com/anthropics/anthropic-sdk-csharp/commit/ba9d1ac2f5b3e86dc4fcf9f5857e550a40ec8995))


### Documentation

* add more info to the readme ([9f20bf2](https://github.com/anthropics/anthropic-sdk-csharp/commit/9f20bf26184307069b94c81d219d732ac46ace50))
* **client:** add more property comments ([a3e973b](https://github.com/anthropics/anthropic-sdk-csharp/commit/a3e973b0e6d057e58e6f0bd08c8a5635da896974))
* fix installation instructions ([4c76768](https://github.com/anthropics/anthropic-sdk-csharp/commit/4c767688eca1a4a873c8f80e266c1600bfd4bafa))
* note alpha status ([cc023e3](https://github.com/anthropics/anthropic-sdk-csharp/commit/cc023e3d5096fc5bdb08f86f85c3afd71090159a))
* streaming in readme ([6063490](https://github.com/anthropics/anthropic-sdk-csharp/commit/6063490d142965cf0be2d937e4d39f5d624a5b84))


### Refactors

* **client:** refine enum representation ([a3e973b](https://github.com/anthropics/anthropic-sdk-csharp/commit/a3e973b0e6d057e58e6f0bd08c8a5635da896974))
* **client:** use plural for service namespace ([843da53](https://github.com/anthropics/anthropic-sdk-csharp/commit/843da53c91a4e925298aae8907f8990b7e13de9e))
