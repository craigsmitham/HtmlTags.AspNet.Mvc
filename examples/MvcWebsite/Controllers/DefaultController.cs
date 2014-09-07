using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

        [HttpPost]
        [Route("")]
        public ActionResult Index(TestViewModel inputModel)
        {
            return !ModelState.IsValid ? (ActionResult)View(inputModel) : RedirectToAction("Success");
        }

        [Route("success")]
        public string Success()
        {
            return "Success!";
        }
    }

    public class TestViewModel
    {
        [Required(ErrorMessage = "You must say something!")]
        public string HelloWorld { get; set; }
    }
}