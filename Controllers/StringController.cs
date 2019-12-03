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
		
		[HttpGet("check/upper")]
		public IActionResult CheckUpper([FromQuery] string s)
		{
			var value = s.Any(char.IsUpper);
			return Ok(value);
			
		}
		
		[HttpGet("check/lower")]
		public IActionResult CheckLower([FromQuery] string s)
		{
			var value = s.Any(char.IsLower);
			return Ok(value);
		}
		
		[HttpGet("check/special")]
		public IActionResult CheckSpecial([FromQuery] string s)
		{
			var value = s.Any(x => !Char.IsLetterOrDigit(x));
			return Ok(value);
		}
		
		[HttpGet("check/number")]
		public IActionResult CheckNumber([FromQuery] string s)
		{
			var value = s.Any(Char.IsDigit);
			return Ok(value);
		}
		
		
    }
}
