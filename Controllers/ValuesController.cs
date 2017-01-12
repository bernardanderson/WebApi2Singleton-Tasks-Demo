using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSingleton.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ThreadSafeSingleton myInstance = ThreadSafeSingleton.Instance;
        
        // GET api/values
        [HttpGet("add")]
        public IActionResult GetMoreInt()
        {
            List<int> returnedResult = myInstance.AddInts(); 
            return Ok(returnedResult);
        }

        [HttpGet("subtract")]
        public IActionResult GetLessInt()
        {
            List<int> returnedResult = myInstance.RemoveLastInt();
            return Ok(returnedResult);
        }
    }
}
