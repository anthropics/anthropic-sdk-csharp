using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class DreamCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DreamCreateParams
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
            Instructions = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        List<BetaDreamInput> expectedInputs =
        [
            new BetaDreamMemoryStoreInput()
            {
                MemoryStoreID = "x",
                Type = BetaDreamMemoryStoreInputType.MemoryStore,
            },
        ];
        Model expectedModel = "string";
        string expectedInstructions = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedInputs.Count, parameters.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], parameters.Inputs[i]);
        }
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DreamCreateParams
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
            Instructions = "x",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DreamCreateParams
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
            Instructions = "x",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DreamCreateParams
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DreamCreateParams
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Instructions = null,
        };

        Assert.Null(parameters.Instructions);
        Assert.True(parameters.RawBodyData.ContainsKey("instructions"));
    }

    [Fact]
    public void Url_Works()
    {
        DreamCreateParams parameters = new()
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/dreams?beta=true"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DreamCreateParams parameters = new()
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["dreaming-2026-04-21", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DreamCreateParams
        {
            Inputs =
            [
                new BetaDreamMemoryStoreInput()
                {
                    MemoryStoreID = "x",
                    Type = BetaDreamMemoryStoreInputType.MemoryStore,
                },
            ],
            Model = "string",
            Instructions = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        DreamCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Model value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaDreamModelConfigParamValidationWorks()
    {
        Model value = new BetaDreamModelConfigParam()
        {
            ID = "x",
            Speed = BetaDreamModelConfigParamSpeed.Standard,
        };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Model value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaDreamModelConfigParamSerializationRoundtripWorks()
    {
        Model value = new BetaDreamModelConfigParam()
        {
            ID = "x",
            Speed = BetaDreamModelConfigParamSpeed.Standard,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
