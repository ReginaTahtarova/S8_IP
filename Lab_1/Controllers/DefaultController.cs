using System;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index(string line)
        {
            var file = Server.MapPath("~/App_Data/data.txt");

            if (!string.IsNullOrWhiteSpace(line))
            {
                System.IO.File.AppendAllText(file, $"{line}{Environment.NewLine}");
            }

            return View();
        }

        public ActionResult All()
        {
            var file = Server.MapPath("~/App_Data/data.txt");

            ViewBag.Lines = System.IO.File.ReadAllLines(file);

            return View();
        }
    }
}