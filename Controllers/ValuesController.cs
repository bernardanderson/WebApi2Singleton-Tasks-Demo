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
        private GenerateNewTasks webApiNewTask = new GenerateNewTasks();
        private ThreadSafeSingleton myInstance = ThreadSafeSingleton.Instance;

        // GET api/values
        [HttpGet("{userName}/start")]
        public IActionResult Start(string userName)
        {
            webApiNewTask.StartNewTask(userName);
            return Ok($"Started counting for {userName}");
        }

        [HttpGet("{userName}/stop")]
        public IActionResult Stop(string userName)
        {
            webApiNewTask.StopThread(userName);
            return Ok($"Stopped counting for {userName}");
        }

        [HttpGet("returnints")]
        public IActionResult ReturnInts()
        {
            return Ok(myInstance.SendInts());
        }

        [HttpGet("returntasks")]
        public IActionResult ReturnTasks()
        {
            int runningNumberOfTasks = myInstance.RetrieveUserTask();
            return Ok($"Running number of counting tasks is: {runningNumberOfTasks}");
        }
    }
}
