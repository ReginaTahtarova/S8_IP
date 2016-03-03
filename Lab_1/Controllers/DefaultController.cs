using System;
using System.IO;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class DefaultController : Controller
    {
        private static readonly string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "data.txt");

        public ActionResult Index(string line)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                System.IO.File.AppendAllText(file, $"{line}{Environment.NewLine}");
            }

            return View();
        }

        public ActionResult All()
        {
            ViewBag.Lines = System.IO.File.ReadAllLines(file);

            return View();
        }
    }
}