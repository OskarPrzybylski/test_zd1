using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using vCards;
using zadanie.Models;

namespace zadanie.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        public static List<Employee> list = new List<Employee>();

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string name)
        {
            var url = "https://adm.edu.p.lodz.pl/user/users.php?search=" + name;
            list = new List<Employee>();
            using (WebClient client = new WebClient())
            {
                var htmlString = client.DownloadString(url);
                var html = new HtmlDocument();
                html.LoadHtml(htmlString);
                var elements = html.DocumentNode.SelectNodes("//div[@class='user-info']");
                foreach (var el in elements)
                {
                    var fullName = el.SelectSingleNode("a").SelectSingleNode("h3").InnerText;
                    var title = el.SelectSingleNode("h4").InnerText;
                    list.Add(new Employee{FullName = fullName, Title = title});
                }

                return Ok(list);
            }
        }

        [HttpGet("vcard")]
        public IActionResult GetVCard(string fullName)
        {
            var emp = list.FirstOrDefault(x => x.FullName == fullName);
            var vCard = new vCard();
            vCard.Title = emp.Title;
            vCard.FormattedName = fullName;
            vCardStandardWriter wrt = new vCardStandardWriter();

            StringWriter sw = new StringWriter();

            // Specify charset to encode non-ascii strings. Use Western-European
            // encoding in this sample (you can also use UTF-8 or whatever).
            wrt.Write(vCard, sw, "UTF-8");
            return File(Encoding.GetEncoding("UTF-8").GetBytes(sw.ToString()), "application/octet-stream", "info.vcf");
        }
    }
}
