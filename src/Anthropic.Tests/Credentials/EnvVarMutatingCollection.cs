namespace Anthropic.Tests.Credentials;

/// <summary>
/// Tests in this collection mutate process-wide environment variables and must
/// not run in parallel with each other.
/// </summary>
[CollectionDefinition("EnvVarMutating", DisableParallelization = true)]
public sealed class EnvVarMutatingCollection { }
