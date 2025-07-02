using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Person ps)
        {
            string str0utput = "Xin chao " + ps.PersonID + "-" + ps.FullName + "-" + ps.Address;
            ViewBag.infoPerson = str0utput;
            return View();
        }
    }
}
