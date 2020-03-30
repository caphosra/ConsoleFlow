# Console Flow - UI for C# Console

[![Badge](https://github.com/capra314cabra/ConsoleFlow/workflows/CI/badge.svg)](https://github.com/capra314cabra/ConsoleFlow/actions)
[![Nuget](https://img.shields.io/nuget/v/ConsoleFlow)](https://www.nuget.org/packages/ConsoleFlow/)
[![Downloads](https://img.shields.io/nuget/dt/ConsoleFlow)](https://www.nuget.org/packages/ConsoleFlow/)
[![License](https://img.shields.io/github/license/capra314cabra/ConsoleFlow)](https://github.com/capra314cabra/ConsoleFlow/blob/master/LICENSE)

![Icon](https://media.githubusercontent.com/media/capra314cabra/ConsoleFlow/master/img/icon-256.png)

This is a C#(dotnet) library for making your design of CUI tool better.

## Demo

### Progress bar example

![ProgressDemo](https://media.githubusercontent.com/media/capra314cabra/ConsoleFlow/master/img/ConsoleProgressExample.gif)

``` C#
// using System;
// using System.Threading.Tasks;
// using ConsoleFlow;

//
// Create ProgressBar components.
//
var firstProgress = new ConsoleProgress(title: "ConsoleProgress", length: 50);

var secondProgress = new SimpleProgress(title: "SimpleProgress", length: 50);

//
// Attach them to ConsoleFlow.
//
var flow = new ConsoleFlow
(
    firstProgress,
    secondProgress
);

//
// Print contents to the terminal.
//
flow.Display();

//
// Change the value of ProgressBar.
// And you will see the components are changed corresponding to the value.
//
// Example:
//
// firstProgress.Value = 0.5f; // 50%
//
```
