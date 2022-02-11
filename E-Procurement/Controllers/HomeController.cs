using Microsoft.AspNetCore.Mvc;

namespace E_Procurement.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from HomeController";
            //return View();
        }
    }
}
