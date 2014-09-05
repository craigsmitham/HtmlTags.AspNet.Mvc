using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace MvcWebsite.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [Route("")]
        public ActionResult Index()
        {
            var model = new TestViewModel();
            return View(model);
        }
    }

    public class TestViewModel
    {
        public string HelloWorld { get; set; }
    }
}