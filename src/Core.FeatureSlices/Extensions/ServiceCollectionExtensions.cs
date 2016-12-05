using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.FeatureSlices.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddFeatureSlices(this IMvcBuilder services, FeatureSlicesOptions options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (options == null)
            {
                throw new ArgumentException(nameof(options));
            }

            var expander = new FeatureViewLocationExpander(options);

            services.AddMvcOptions(o =>
            {
                o.Conventions.Add(new FeatureControllerModelConvention(options));
            })
            .AddRazorOptions(o =>
            {
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add(options.FeatureNamePlaceholder + @"\{0}.cshtml");
                o.ViewLocationFormats.Add(options.FeatureFolderName + @"\Shared\{0}.cshtml");
                o.ViewLocationExpanders.Add(expander);
            });

            return services;
        }

        public static IMvcBuilder AddFeatureSlices(this IMvcBuilder services)
        {
            return AddFeatureSlices(services, new FeatureSlicesOptions());
        }
    }
}
