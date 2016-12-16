using Core.FeatureSlices.Tests.Features;
using Core.FeatureSlices.Tests.Features.Reporting;
using Core.FeatureSlices.Tests.Features.Reporting.BI.Data;
using Core.FeatureSlices.Tests.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Mvc.RazorFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Core.FeatureSlices.Tests
{
    public class RazorFeatureTests
    {
        public RazorFeatureTests()
        {

        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { typeof(HomeController), HomeController.ExpectedPath };
            yield return new object[] { typeof(SalesManagerController), SalesManagerController.ExpectedPath };
            yield return new object[] { typeof(DataController), DataController.ExpectedPath };
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void CanGetPathFromControllerWithDeafultOptions(Type controller, string expected)
        {
            var defaultOptions = new RazorFeaturesOptions();
            var convention = new RazorFeaturesControllerModelConvention(defaultOptions);
            var controllerModel = new ControllerModel(controller.GetTypeInfo(), new List<string>());

            convention.Apply(controllerModel);
            Assert.Equal(expected, controllerModel.Properties[RazorFeaturesControllerModelConvention.FeatureControllerPropertyName]);
        }




    }

}
