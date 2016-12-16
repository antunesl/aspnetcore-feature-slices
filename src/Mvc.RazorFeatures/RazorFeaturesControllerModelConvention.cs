using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.RazorFeatures
{
    public class RazorFeaturesControllerModelConvention : IControllerModelConvention
    {
        public const string FeatureControllerPropertyName = "feature";
        private readonly string _folderName;
        private readonly Func<ControllerModel, string> _nameDerivationStrategy;

        public RazorFeaturesControllerModelConvention(RazorFeaturesOptions options)
        {
            _folderName = options.FeatureFolderName;
            _nameDerivationStrategy = options.DeriveFeatureFolderName ?? DeriveFeatureFolderName;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            var featureName = _nameDerivationStrategy(controller);
            controller.Properties.Add(FeatureControllerPropertyName, featureName);
        }

        private string DeriveFeatureFolderName(ControllerModel model)
        {
            var @namespace = model.ControllerType.Namespace;
            var result = @namespace.Split('.')
                  .SkipWhile(s => s != _folderName)
                  .Aggregate("", Path.Combine);

            return result;
        }
    }
}
