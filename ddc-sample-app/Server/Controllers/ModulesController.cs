using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ddc_sample_app.Server.Controllers
{
    [ApiController]
    [Route("/api/modules")]
    public class ModulesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var files = Directory.GetFiles("modules-bin");
            var modules = new List<string>(files.Select(m => $"/{m.Replace('\\', '/')}"));
            return Json(modules);
        }
    }
}
