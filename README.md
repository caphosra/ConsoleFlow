# Console Flow - UI for C# Console

[![Badge](https://github.com/capra314cabra/ConsoleFlow/workflows/CI/badge.svg)](https://github.com/capra314cabra/ConsoleFlow/actions)
[![Nuget](https://img.shields.io/nuget/v/ConsoleFlow)](https://www.nuget.org/packages/ConsoleFlow/)

![Icon](https://github.com/capra314cabra/ConsoleFlow/blob/master/img/icon-256.png)

This is a C#(dotnet) library for making your design of CUI tool better.

## Demo

### Progress bar example

![ProgressDemo](https://github.com/capra314cabra/ConsoleFlow/blob/master/img/ProgressBarExample.gif)

``` C#
// using System;
// using System.Threading.Tasks;
// using ConsoleFlow;

//
// Create ProgressBar components.
//
var firstProgress = new ConsoleProgressBar(title: "First", length: 100);

var secondProgress = new ConsoleProgressBar(title: "Second", length: 100);

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
// Example: firstProgress.Value = 0.5f; // 50%
//

//
// Wait user input for preventing from finishing.
//
Console.ReadKey();
```
