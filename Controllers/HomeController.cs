using Microsoft.AspNetCore.Mvc;
namespace Dojo_survey
{
    public class HomeController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string name, string location,string language,string comment)
        {
            // Do something with form input
            var AnonObject = new
            {
                name = name,
                location = location,
                language = language,
                comment = comment,
            };
            // return Json(AnonObject);
            return RedirectToAction("ResultMethod",AnonObject);
        }

        [HttpGet]
        [Route("result")]
        // public ViewResult Result(string name, string location, string language, string comment)
        public ViewResult ResultMethod(string name, string location, string language, string comment)
        {
          
            ViewBag.userName = name;
            ViewBag.userLocation = location;
            ViewBag.userLanguage = language;
            ViewBag.userComment = comment;
            
            return View("Result");
        }
    }
}