using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.FeatureSlices.Tests.Features
{
    public class HomeController
    {
        public static string ExpectedPath = "Features";
    }
}


namespace Core.FeatureSlices.Tests.Features.Sales
{
    public class SalesManagerController
    {
        public static string ExpectedPath = @"Features\Sales";
    }
}

namespace Core.FeatureSlices.Tests.Features.Reporting.BI.Data
{
    public class DataController
    {
        public static string ExpectedPath = @"Features\Reporting\BI\Data";
    }
}
