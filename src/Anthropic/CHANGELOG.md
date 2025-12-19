# Changelog

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
