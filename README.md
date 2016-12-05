# aspnetcore-feature-slices
### ASP-NET Core Feature Slices

**Organize ASP.NET Core project files by application feature.**

This was created with inspirations from the [article from Steve Smith](https://msdn.microsoft.com/en-us/magazine/mt763233.aspx)



**Usage:**
```c#
public class Startup
{
...
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddFeatureSlices();
    }
...
}
```



