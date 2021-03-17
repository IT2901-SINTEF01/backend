# Open Data Visualisation Platform – Backend

![.NET](https://github.com/IT2901-SINTEF01/backend/workflows/.NET/badge.svg)
![Open issues](https://img.shields.io/github/issues/IT2901-SINTEF01/backend)
![Apache 2 License](https://img.shields.io/github/license/IT2901-SINTEF01/backend)
![Latest Release](https://img.shields.io/github/v/release/IT2901-SINTEF01/backend?include_prereleases)
[![codecov](https://codecov.io/gh/IT2901-SINTEF01/backend/branch/master/graph/badge.svg)](https://codecov.io/gh/IT2901-SINTEF01/backend)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/80baa14e3a6a4f138ae383c66baf1935)](https://www.codacy.com/gh/IT2901-SINTEF01/backend/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=IT2901-SINTEF01/backend&amp;utm_campaign=Badge_Grade)

<img src="./SINTEF_logo.png" alt="SINTEF" height=50 />

_This repository contains the backend for the "Open Data Visualisation Platform" developed in collaboration with [SINTEF](https://sintef.no). You may find the frontend [here](https://github.com/IT2901-SINTEF01/frontend). Providing a GraphQL interface, it will supply the frontend with data from various open data sources as well as attached metadata for the data to simplify the visualisation of the raw data. Consult the [releases](https://github.com/IT2901-SINTEF01/backend/releases) page to get a local, stable copy of the service._

## Overview

The backend is built on ASP.Net Core with `GraphQL.Server` and written in C#.
Refer to the [wiki](https://github.com/IT2901-SINTEF01/backend/wiki) for more information such as architecture and structure.

## Quick setup with Docker

Refer to [the wiki page](https://github.com/IT2901-SINTEF01/backend/wiki/Docker) for more information;

You can run the project in production mode (making actual requests to the APIs) with.

This pulls the latest stable build (released with a tag):

```bash
docker pull ghcr.io/it2901-sintef01/backend:latest
docker run -p 5000:80 ghcr.io/it2901-sintef01/backend:latest
```

## Development

Refer to the `.editorconfig` file for code style setup. 

The initial development team use [Rider](https://www.jetbrains.com/rider/) for development.

## Running

You can run the project with

```bash
dotnet run
```

Visit the GraphQL playground at [https://localhost:5001/ui/playground](https://localhost:5001/ui/playground).

## Testing

Run the test suite with 

```bash
dotnet test
```

## License

```
Copyright 2021 SINTEF AS

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```
