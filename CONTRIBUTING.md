## Setting up the environment

To set up the repository, run:

```sh
$ ./scripts/bootstrap
$ ./scripts/build
```

This will install required dependencies and build the SDK.

## Modifying/Adding code

Most of the SDK is generated code. Modifications to code will be persisted between generations, but may
result in merge conflicts between manual patches and changes from the generator. The generator will never
modify the contents of the `examples/` directory.

## Using the repository from source

To use a local version of this library from source in another project, add it using a directory reference:

```sh
$ dotnet add reference /path/to/sdk/src/Anthropic
```

## Formatting and linting

```sh
$ ./scripts/format
$ ./scripts/lint
```

## Running tests

```sh
$ ./scripts/test
```
