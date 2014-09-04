HangFire.TinyIoC
================

[![Build status](https://ci.appveyor.com/api/projects/status/o5fdyjwi1f38xjmm)](https://ci.appveyor.com/project/RichClement/hangfire-tinyioc)

[HangFire](http://hangfire.io) background job activator based on [TinyIoC](https://github.com/grumpydev/TinyIoC) Container. It allows you to use instance methods of classes that define parameterized constructors

Installation
------

HangFire.TinyIoC is available as a NuGet Package. Type the following command into the Nuget package Manager Console window to install it:

```
Install-Package Hangfire.TinyIoC
```

Usage
------

This package provides an extension method for [OWIN bootstrapper](http://docs.hangfire.io/en/latest/users-guide/getting-started/owin-bootstrapper.html):

```csharp
app.UseHangfire(config =>
{
	var container = new TinyIoCContainer();
	config.UseTinyIoCActivator(container);
});
```

In order to use the library outside of web application, set the static JobActivator.Current property:

```csharp
var container = new TinyIoCContainer();
JobActivator.Current = new TinyIoCJobActivator(container);
```
