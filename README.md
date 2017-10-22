cacheable
====================

[![Build status](https://ci.appveyor.com/api/projects/status/w91o128dbwdwvj8a?svg=true)](https://ci.appveyor.com/project/neekgreen/cacheable)
[![NuGet](https://img.shields.io/nuget/v/cacheable.svg)](https://www.nuget.org/packages/cacheable) 
[![NuGet](https://img.shields.io/nuget/dt/cacheable.svg)](https://www.nuget.org/packages/cacheable) 
[![CodeFactor](https://www.codefactor.io/repository/github/neekgreen/cacheable/badge)](https://www.codefactor.io/repository/github/neekgreen/cacheable)

A set of extensions to provide caching support on MediatR based request handlers.

[![something](https://img.shields.io/badge/.netstandard-2.0-blue.svg)](https://img.shields.io/badge/.netstandard-1.3-blue.svg)

## Installing Cacheable

You should install [Cacheable with NuGet](https://www.nuget.org/packages/cacheable):

    Install-Package Cacheable
    
This command will download and install Cacheable. Let me know if you have questions!

## Using Cacheable

Cacheable requires MediatR and your IoC container of choice. The decorator pattern is used to wrap the `IRequestHandler` and `IAsyncRequestHandler` classes with 

### With StructureMap

```
For(typeof(IRequestHandler<,>)).DecorateAllWith(typeof(MemoryCacheRequestHandler<,>));
```

```
For(typeof(IAsyncRequestHandler<,>)).DecorateAllWith(typeof(MemoryCacheAsyncRequestHandler<,>));
```

### With Microsoft.Extensions.DependencyInjection and Sructor
--TBD

### With Autofac
--TBD