using Microsoft.AspNetCore.Mvc;
using MyLittleDic.Models;

namespace MyLittleDic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet(Name = "GetEntry")]
        public IEnumerable<Entry> Get()
        {
            Entry entry = new Entry();

            //return entry.GetEntries().ToArray();
        }
    }
}
