using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Controllers
{
    [Route("api/test")]
    public class TestController
    {
        private readonly IServiceProvider serviceProvider;

        public TestController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        public int Get()
        {
            var t1 = Task.Run(() => serviceProvider.GetService<Service>());
            var t2 = Task.Run(() => serviceProvider.GetService<Service>());
            Task.WaitAll(t1, t2);


            return t1.Result.Count;
        }

    }
}
