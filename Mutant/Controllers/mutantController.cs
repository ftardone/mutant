using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mutant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class mutantController : Controller
    {
        [HttpPost]
        public IActionResult Index(string[] dna)
        {
            //return View();
            bool response = false;
            int count_A = 0;
            int count_T = 0;
            int count_C = 0;
            int count_G = 0;
            int coincidencias = 0;

            foreach (string item in dna)
            {
                if (item.ToLower().Count(f => f == 'a') > 3) { coincidencias++; }
                if (item.ToLower().Count(f => f == 't') > 3) { coincidencias++; }
                if (item.ToLower().Count(f => f == 'c') > 3) { coincidencias++; }
                if (item.ToLower().Count(f => f == 'g') > 3) { coincidencias++; }

                if (coincidencias > 1) { response = true; break; }
            }

            return response ? Ok() : StatusCode(403);
        }
    }
}
