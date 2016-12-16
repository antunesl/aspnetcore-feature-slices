using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.RazorFeatures.SampleWebApp.Features.Management.UserAccounts
{
    public class UserAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
