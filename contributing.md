# Contributing

Contributing back to these projects is very much appreciated. Whether you feel the need to change a single character or have a go at implementing a new integration, no pull request (PR) is too small or too big.

In fact many of our most awesome features/fixes have been provided to us by [these wonderful folks](https://github.com/elastic/ecs-dotnet/graphs/contributors) to which we are forever indebted. 

It's usually best to open an issue first to discuss a feature or bug, before opening a pull request. Doing so can save time and help further determine the fundamentals of an issue.

## Code of Conduct

Please read the Elastic [Community Code of Conduct](https://www.elastic.co/community/codeofconduct) to understand our stance on community engagement.

## Sign the CLA

We do ask that you sign the [Elasticsearch CLA](https://www.elastic.co/contributor-agreement) before we can accept pull requests from you. 

## Coding Styleguide

Please install the [Editorconfig Visual Studio extension](https://visualstudiogallery.msdn.microsoft.com/c8bccfe2-650c-4b42-bc5c-845e21f96328) this will automatically switch to our indentation, whitespace, newlines settings while working on our project **while leaving your default settings intact**.

In most cases we won't shun a PR just because it uses the wrong indentation settings, though it'll be **very** much appreciated if it is already done!

## Tests

PRs with tests are more likely to be reviewed faster because it makes the job of reviewing the PR much easier. That being said,
we respect that you may be fixing a bug for yourself and may not have the time or energy to submit a PR with complete tests. 

In those cases we tend to pull your code locally and write tests ourselves, but this may mean your PR might sit idle longer than you would like.

## Branches

Convention:

- `main` reflects the latest Elastic Common Schema (ECS) version, this is typically the `current latest major + 1`
- `X.Y.Z` where `X` is the major version, `Y` is the minor component and `Z` is the patch component, typically opened as integration branch for a specific minor.

Examples:

- `main` for the latest ECS version
- `1.2.0` for ECS 1.2.0 compatible integrations

# Building the solution

The solution uses a number of awesome Open Source software tools to ease development:

## Bullseye

[Bullseye](https://github.com/adamralph/bullseye) is used as the build automation system for the solution. To get started after cloning the solution, it's best to run the build script in the root directory.

for Windows 

```
.\build.bat
```

for OSX/Linux

```
./build.sh
```

This will

- Pull down all the dependencies for the build process as well as the solution
- Run the default build target for the solution

You can also compile the solution within Visual Studio if you prefer, but the build script is going to be _much_ faster.

For the full list of options available you are able to run:

```
.\build.bat help
```

## Tests

The `tests` folder contains unit and integration tests.

### Compile and run unit tests

```bat
.\build.bat
```

...with no target will run the `build` target, compiling the solution and running unit tests.
