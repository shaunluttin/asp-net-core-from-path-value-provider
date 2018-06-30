using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCoreUriToAssoc
{
    public class PropertiesController : Controller
    {
        public IActionResult Search([FromPath]BedsEtCetera model)
        {
            return Json(model);
        }
    }
}
