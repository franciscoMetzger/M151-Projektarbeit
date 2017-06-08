using System.Web.Mvc;

namespace Skivermietung.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Ski- und Snowboardvermietung";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Kontakt";

			return View();
		}
	}
}