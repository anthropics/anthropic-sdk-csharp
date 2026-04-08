using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class EventSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventSendParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Events =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        List<BetaManagedAgentsEventParams> expectedEvents =
        [
            new BetaManagedAgentsUserMessageEventParams()
            {
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
            },
        ];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.Equal(expectedEvents.Count, parameters.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], parameters.Events[i]);
        }
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
        var parameters = new EventSendParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Events =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventSendParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Events =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        EventSendParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Events =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/sessions/sesn_011CZkZAtmR3yMPDzynEDxu7/events?beta=true"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EventSendParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Events =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventSendParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Events =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        EventSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
