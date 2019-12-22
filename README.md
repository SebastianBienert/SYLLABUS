# app-team07
app-team07 created by GitHub Classroom

## Features

* Hot module replacement
* Code-splitting
* Tree-shaking
* ES2017 transpilation
* Long term caching and so on

## Used Technology Stack

**ASP.NET Core 3.0:**

* Web.API
* Vue CLI and JavaScript Services middlewares to integrate with client app

**Vue.js with CLI 4.0 supporting optional integrations:**

* TypeScript
* Progressive Web App
* Vue Router & Vuex (State Store)
* Linting, unit testing, E2E testing
* 3rd party component frameworks (Vuetify, Vue Bootstrap etc.)
* publish your personal/enterprise plugin and so on...

## Prerequisites

* [.NET Core](https://www.microsoft.com/net/download/windows) >= 3.0
* [NodeJS](https://nodejs.org/) >= 8.9
* [Vue CLI](https://cli.vuejs.org/) >= 4.0
* Your favourite editor (I prefer [VS Code](https://code.visualstudio.com/)), or VS 2017/19

## Before running application
### Initialize database
1. Set proper connection string in apsettings.Development.json file
2. Run `update-database` from package manager console (VS 2019) or `dotnet ef update-database` from cmd (VS Code)

## Run the application

You have two choices when it comes to how you prefer to run the app. You can either use the command line or the build-in run command.

### 1. Using the command line

* Run the .NET application using `dotnet run`

### 2. Using the built-in run command

* Run the application in VSCode or Visual Studio 2017 by hitting `F5`

> It will take some time during the first run to download all client side dependencies.

## View your application running

Browse to [http://localhost:5000](http://localhost:5000) for ASP.&#8203;NET Core + Vue app or browse to [http://localhost:8080](http://localhost:8080) for Vue app only.

![Application screenshot](./screenshot.png)

## Recommended plugin for debugging Vue

* Get Chrome DevTools for Vue.js [here](https://chrome.google.com/webstore/detail/vuejs-devtools/nhdogjmejiglipccpnnnanhbledajbpd)
