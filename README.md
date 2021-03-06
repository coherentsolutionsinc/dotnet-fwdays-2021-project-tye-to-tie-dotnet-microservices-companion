# "Project Tye to Tie Micro-services" companion

This repository contains a companion project (used in [solution-3](https://github.com/coherentsolutionsinc/dotnet-fwdays-2021-project-tye-to-tie-dotnet-microservices/tree/main/solution-3) as remote repository) demonstrated on .NET fwdays'21 conference on 2021-08-07. 

## Content

The repository contains:

* **.vscode/launch.json** - launch configuration for Docker container debugging (used in demo to debug `companion-containerized-api` service).
* **companion-containerized-api** - a .NET 5 service to generate random weather forecast information. 
* **companion-source-api** - a .NET 5 service which enriches weather forecast obtained from `companion-containerized-api` service source information. 
* **request.http** - a list of requests for the application (used in demo). 
* **tye.yaml** - configuration of `tye` tool.

## Details

* `companion-containerized-api` service is built from `companion-containerized-api/Dockerfile`.
* `companion-source-api` service is built from `companion-source-api/companion-source-api.csproj`.

## Prerequisites

Please ensure to install:

* [REST Client](https://github.com/Huachao/vscode-restclient) extension for Visual Studio Code.

> Developer's comment 
>
> This is required to execute requests from `request.http` file.

* [Docker](https://github.com/microsoft/vscode-docker) extension for Visual Studio Code.

> Developer's comment
> 
> This is required to debug service containers

* [Project Tye](https://github.com/dotnet/tye) is installed and getting started [tutorial](https://github.com/dotnet/tye/blob/main/docs/tutorials/hello-tye/00_run_locally.md) is finished.

## Demo

1. Take a look at `tye.yaml`. 
    * Pay attention to fixed ports in `bindings` (which are required to simplify demonstration by using `requests.http`). 
    * Pay attention to `containerPort` configuration.
3. Take a look at `companion-source-api/Startup.cs`. 
    * Pay attention to usage of Tye extension method for configuration.
5. Execute `tye run` command. 
6. Open [Project Tye Extension](https://github.com/Microsoft/vscode-tye/). 
7. Navigate and demonstrate dashboard
    * Pay attention to `Project` vs `Container`.
    * Pay attention to bindings.
9. Open to `request.http`. 
    * Execute request to `companion-containerized-api`. 
    * Execute request to `companion-source-api`. 
    * Pay attention to differences.
11. Use Tye extension to attach debugger to `companion-source-api`. 
    * Pay attention that currently there is no built in way to attach debugger to container. 
    * Verify debugger works (in `WeatherForecastController`).
    * Use Visual Studio Code "Docker .NET Core Attach (Preview)" debug configuration to debug `companion-containerized-api` service.
    * Detach debuggers. 
    * CTRL+C to cancel `tye run`.
15. Execute `tye deploy -i` (specify required container registry).
16. Use `kubectl` to
    * View services
        * `kubectl get service`
    * Establish port forwarding for `companion-source-api` 
        * `kubectl port-forward svc/companion-source-api 8800:8800`
18. Open `request.http` and execute request to `companion-containerized-api`.
19. Execute `tye undeploy`.

## Authors
This project is owned by [Coherent Solutions](www.coherentsolutions.com).

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) for details.
