using System.Drawing;
using System.Drawing.Imaging;
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
            var image = Helper.ConvertTextToImage(name, new Font("Courier New", 15), Color.Black, Color.White);
            var stream = Helper.ToStream(image, ImageFormat.Png);

            return File(stream, "image/png");
        }
    }
}