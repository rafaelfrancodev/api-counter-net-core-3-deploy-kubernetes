using KubernetesCounter.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KubernetesCounter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : Controller
    {
        private static Counter _COUNTER = new Counter();

        [HttpGet]
        public object Get()
        {
            lock(_COUNTER)
            {
                _COUNTER.Increment();

                return new
                {
                    _COUNTER.CurrentValue,
                    Environment.MachineName,
                    OSVersion = Environment.OSVersion.VersionString
                };
            }
        }
    }
}