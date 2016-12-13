# Asp.Net Core Feature Slices

**Organize ASP.NET Core project files by application feature.**

This was created with inspirations from the [MSDN article from Steve Smith](https://msdn.microsoft.com/en-us/magazine/mt763233.aspx).



**Usage:**
```c#
public class Startup
{
...
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddProjectStructureByFeature();
    }
...
}
```

**Project Structure:**
```
Project
|-Features
|  |- Home
|  |    |- Home.cshtml
|  |    |- HomeController.cs
|  |- Shared
|  |    |- _Layout.cshtml
|- ...
|- Startup.cs
|- Program.cs
```



