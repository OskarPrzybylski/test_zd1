using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace zadanie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringController : ControllerBase
    {
        public StringController()
        {
        }

        [HttpGet]
        public IActionResult ReverseString([FromQuery] string s)
        {
            char[] charArray = s.ToCharArray();
			Array.Reverse( charArray );
			return Ok(new string(charArray));
        }
    }
}
