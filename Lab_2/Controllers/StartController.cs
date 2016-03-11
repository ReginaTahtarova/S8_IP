using System.Web.Mvc;

namespace Lab_2.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Image(string name)
        {
            var stream = name
                .ToImage()
                .ToStream();

            return File(stream, "image/png");
        }
    }
}