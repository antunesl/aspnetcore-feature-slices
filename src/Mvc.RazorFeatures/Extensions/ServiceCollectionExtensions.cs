using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.FeatureSlices.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddRazorByFeatures(this IMvcBuilder services, RazorFeaturesOptions options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (options == null)
            {
                throw new ArgumentException(nameof(options));
            }

            var expander = new RazorFeaturesViewLocationExpander(options);

            services.AddMvcOptions(o =>
            {
                o.Conventions.Add(new RazorFeaturesControllerModelConvention(options));
            })
            .AddRazorOptions(o =>
            {
                if (!options.KeepDefaultViewLocation)
                    o.ViewLocationFormats.Clear();

                o.ViewLocationFormats.Insert(0, options.FeatureNamePlaceholder + @"\{0}.cshtml");
                o.ViewLocationFormats.Insert(0, options.FeatureNamePlaceholder + @"\Shared\{0}.cshtml");
                o.ViewLocationFormats.Insert(0, options.FeatureFolderName + @"\Shared\{0}.cshtml");

                o.ViewLocationExpanders.Add(expander);
            });

            return services;
        }

        public static IMvcBuilder AddRazorByFeatures(this IMvcBuilder services)
        {
            return AddRazorByFeatures(services, new RazorFeaturesOptions());
        }
    }
}
