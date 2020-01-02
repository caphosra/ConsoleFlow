# Terminal Flow - UI for C# Console

[![Badge](https://github.com/capra314cabra/terminal-flow/workflows/CI/badge.svg)](https://github.com/capra314cabra/terminal-flow/actions)
[![Nuget](https://img.shields.io/nuget/v/TerminalFlow)](https://www.nuget.org/packages/TerminalFlow/)

![Icon](https://github.com/capra314cabra/terminal-flow/blob/master/img/icon-256.png)

This is a C#(dotnet) library for making your design of CUI tool better.

## Demo

### Progress bar example

![ProgressDemo](https://github.com/capra314cabra/terminal-flow/blob/master/img/ProgressBarExample.gif)

``` C#
// using System;
// using System.Threading.Tasks;
// using TerminalFlow;

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
