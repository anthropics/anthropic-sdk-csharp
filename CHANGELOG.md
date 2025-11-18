# Changelog

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
