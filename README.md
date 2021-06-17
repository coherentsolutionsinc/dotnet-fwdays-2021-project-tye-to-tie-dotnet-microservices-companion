# "Project Tye to Tie Micro-services" companion

This repository contains a companion solution demonstrated on .NET fwdays'21 conference on 2021-08-07. 

Here is repository structure:

1. `.vscode/launch.json` - contains a Docker debug configuration which can be used to debug `companion-containerized-api`
2. `companion-containerized-api` - a weather forecast service which is built using `companion-containerized-api/Dockerfile`. This service generates a dummy weather information.
3. `companion-source-api` - a weather forecast service which calls weather forecast API of `companion-containerized-api` and enriches response with source information. This service is built from sources.
4. `request.http` - contains predefined requests for testing the application. These requests can be executed by (REST Client)[https://github.com/Huachao/vscode-restclient] for Visual Studio Code.
5. `tye.yaml` - contains configuration for `tye` command tool.

Here is a demo scenario:

1. Take a look at `tye.yaml`. Pay attention to fixed ports in `bindings` (which are required to simplify demonstration by using `requests.http`). Pay attention to `containerPort` configuration.
2. Take a look at `companion-source-api/Startup.cs`. Pay attention to usage of Tye extension method for configuration.
3. Execute `tye run` command. Open (Project Tye Extension)[https://github.com/Microsoft/vscode-tye/]. Demonstrate dashboard - pay attention to `Project` vs `Container`, pay attention to bindings.
4. Navigate to `request.http`. Execute request to `companion-containerized-api`. Execute request to `companion-source-api`. Pay attention to differences.
5. Use Tye extension to attach debugger to `companion-source-api`. Pay attention that currently there is no built in way to attach debugger to container. Demonstrate that debugging works (in `WeatherForecastController`).
6. Use Visual Studio Code "Docker .NET Core Attach (Preview)" debug configuration to debug `companion-containerized-api` service.
7. Detach debuggers. CTRL+C to cancel `tye run`.
8. Execute `tye deploy -i` (specify required container registry).
9. Use `kubectl` to get services (`kubectl get service`) and port forward `companion-source-api` port to 8801 port (`kubectl port-forward svc/companion-source-api 8800:8800`).
10. Execute request to `companion-containerized-api` (from `request.http`).
11. Execute `tye undeploy`.