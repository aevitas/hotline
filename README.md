# Hotline
The only number you'll need to dial when things go south. 

Hotline is a middleware component for ASP.NET Core that enabled you to report unhandled exceptions to external error tracking services.

You can obtain the package relevant to the error reporting service you're using from NuGet:
![Sentry](https://i.imgur.com/W0kG3Rg.png)

## Usage
We'll configure Hotline for Sentry in this introduction. Sentry requires a DSN to make a connection; add the following to your `appSettings.json`:

```
  "Sentry": {
    "Dsn": "{your_DSN_here}"
  } 
```
  
Now we'll call `Configure<SentryOptions>` to wire up the configuration the middleware requires in `Startup.cs`:

```csharp
services.Configure<SentryOptions>(Configuration.GetSection("Sentry"));
```

Register the `SentryHotline` provider with the DI container:

```csharp
services.AddScoped<IHotline, SentryHotline>();
```

Then finally, install the middleware:

```csharp
app.UseHotline();
```

Make sure the Hotline middleware component added to the pipeline, so definitely **before** `app.UseMvc()` and any other middleware you are running.

And that's all - any unhandled exceptions will now be automatically reported to Sentry in full.

## Contributions
Any and all contributions, new providers for Hotline, bugfixes, features, are welcome. It is preferred contributions follow the [netcore code style guidelines](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md) as well as the relevant C# conventions. 
