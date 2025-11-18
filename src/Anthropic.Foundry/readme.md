# Anthropic.Foundry

Lightweight C# bindings for the Anthropic Foundry surface in the Anthropic SDK for .NET. This project contains the Anthropic.Foundry library used by the solution to interact with Foundry APIs, plus helpers and models used across samples and integrations.

## Contents
- Library source: src/Anthropic.Foundry
- Unit/integration tests: tests (if present)
- Samples and usage examples: examples (if present)

## Requirements
- .NET SDK (installed and available on PATH)
- An Anthropic API key (set via environment variable or configuration). See example down below.

## Installation

`dotnet add package Anthropic.Foundry`

## Quick start
Set your API key in the environment before running:

- Linux/macOS
export ANTHROPIC_FOUNDRY_API_KEY="..."
export ANTHROPIC_FOUNDRY_RESOURCE="..."

- Windows (PowerShell)
$env:ANTHROPIC_FOUNDRY_API_KEY = "..."
$env:ANTHROPIC_FOUNDRY_RESOURCE = "..."

Example usage (simplified):

```csharp
using System;
using Anthropic;
using Anthropic.Models.Messages;
using Anthropic.Foundry;

// For loading Key and Region from env variables use this:
AnthropicFoundryClient client = new(IAnthropicFoundryCredentials.FromEnv());

// For providing an x-api-key use this
AnthropicFoundryClient client = new(new AnthropicFoundryApiKeyCredentials("API-TOKEN", "RESOURCE-NAME"));

MessageCreateParams parameters = new()
{
    MaxTokens = 2048,
    Messages =
    [
        new() { Content = "Tell me a story about building the best SDK!", Role = Role.User },
    ],
    Model = "claude-sonnet-4-5",
};

var response = await client.Messages.Create(parameters);

var message = String.Join(
    "",
    response
        .Content
        .Where(message => message.Value is TextBlock)
        .Select(message => message.Value as TextBlock)
        .Select((textBlock) => textBlock.Text)
);

Console.WriteLine(message);

```
