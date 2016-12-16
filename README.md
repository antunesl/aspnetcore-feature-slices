# Asp.Net Core MVC Razor Features

**Organize ASP.NET Core MVC project files by Application Feature.**

This was created with inspirations from the [MSDN article from Steve Smith](https://msdn.microsoft.com/en-us/magazine/mt763233.aspx).


**Usage**
```c#
public class Startup
{
...
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddRazorByFeatures(new RazorFeaturesOptions
        {
		...
        });
    }
...
}
```

**Options**
```c#
/// <summary>
/// The name of the feature folder. The default value is 'Features'
/// </summary>
public string FeatureFolderName { get; set; }

/// <summary>
/// Given a ControllerModel, this returns the path for the feature folder, assuming the 
/// Feature folder name is given by <see cref="FeatureFolderName"/> property.
/// This option allows to override the default behavior. The default behavior takes 
/// the namespace of a Controller and assumes the namespace maps to a folder.
/// </summary>
/// <example> 
///     Mvc.RazorFeatures.SampleWebApp.Features.Home => Features\Home
///     Mvc.RazorFeatures.SampleWebApp.Features.Management.UserAccounts => Features\Management\UserAccounts
/// </example>
public Func<ControllerModel, string> DeriveFeatureFolderName { get; set; }


/// <summary>
/// The <see cref="RazorFeaturesViewLocationExpander"/> replaces this placeholder with 
/// the obtained path from the ControllerModel. The default values is '{Feature}'.
/// Note that Razor defines {0} as view Name and {1} as controller.
/// </summary>
public string FeatureNamePlaceholder { get; set; }

/// <summary>
/// Keep default Razor view location behavior, and just add new ViewLocationFormats strings 
/// (without clear existing ones) to get the feature structure behavior.
/// </summary>
public bool KeepDefaultViewLocation { get; set; }
```

**Project Structures**
```
Project
|-Features
|  |- Home
|  |    |- Index.cshtml
|  |    |- HomeController.cs
|  |- Management
|  |    |- UserAccounts
|  |    |    |- Index.cshtml
|  |    |    |- UserAccountsController.cs
|  |- Shared
|  |    |- _Layout.cshtml
|- ...
|- Startup.cs
|- Program.cs
```

See [SampleWebApp project](/sample/Mvc.RazorFeatures.SampleWebApp) for an example.



