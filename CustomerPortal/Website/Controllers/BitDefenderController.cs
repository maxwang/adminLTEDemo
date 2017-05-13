using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Extensions;

namespace Website.Controllers
{
    public class BitDefenderController : Controller
    {
        //[AuthorizeClaim("test", "test")]
        [ClaimAuthorize("CustomerPortal.Module", "BitDefender")]
        public IActionResult Index()
        {
            return View();
        }
    }
}