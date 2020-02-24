# Linux docker build for building and testing the ecs-dotnet

This is a Docker container with the dotnet SDK and the test tools required to run the
build and test goals for the linux OS.

## How to use it

```bash
## Build docker image
docker build -t sdk .ci/docker/sdk-linux

## Run container to build the ecs-dotnet
docker run --rm -ti \
       --name ecs-dotnet \
       -u "$(id -u):$(id -g)" \
       -v $(pwd):/src \
       -w /src \
       -e HOME=/tmp \
       sdk:latest \
       /bin/bash -c './build.sh'

## Run container to test the ecs-dotnet
docker run --rm -ti \
       --name ecs-dotnet \
       -u "$(id -u):$(id -g)" \
       -v $(pwd):/src \
       -w /src \
       -e HOME=/tmp \
       sdk:latest \
       /bin/bash -c './test.sh'
```
