using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Serialization.iCalendar.Serializers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace zadanie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public string GetEvents([FromQuery] string year, [FromQuery] string month)
        {
            var listOfEvents = new Dictionary<string, string>();
            using (WebClient client = new WebClient())
            {
                var tempHtml = client.DownloadString("http://www.weeia.p.lodz.pl/pliki_strony_kontroler/kalendarz.php?rok=" + year + "&miesiac=" + month + "&lang=1");
                var htmlCode = System.Net.WebUtility.HtmlDecode(tempHtml);
                var lines = htmlCode.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                
                foreach (var line in lines)
                {
                    if (line.Contains("<a class='active'"))
                    {
                        var newLine = line.Replace("</tr><tr class='dzien'>", "");

                        while (newLine.Length != 0)
                        {
                            var dzien = newLine.Substring(newLine.IndexOf("<td"), newLine.IndexOf("</td>") + 5 - newLine.IndexOf("<td"));

                            if (dzien.Contains("InnerBox"))
                            {
                                var dayTemp = dzien.Substring(dzien.IndexOf("void();\">") + 9, dzien.IndexOf("</a>") - dzien.IndexOf("void();\">") + 9);
                                var day = dayTemp.Substring(0, dayTemp.IndexOf("</a>"));
                                var evenTemp = dzien.Substring(dzien.IndexOf("<p>") + 3, dzien.IndexOf("</p>") - dzien.IndexOf("<p>") + 3);
                                var even = evenTemp.Substring(0, evenTemp.IndexOf("</p>"));
                                listOfEvents.Add(day, even);

                            }
                            newLine = newLine.Replace(dzien, "");
                        }
                    }
                }
                

                var calendar = new Calendar();
                foreach(var element in listOfEvents)
                {
                    var e = new CalendarEvent
                    {
                        Summary = element.Value,
                        IsAllDay = true,
                        Start = new CalDateTime(new DateTime(int.Parse(year), int.Parse(month), int.Parse(element.Key)))
                    };
                    calendar.Events.Add(e);
                }

                var serializer = new CalendarSerializer();
                var serializedCalendar = serializer.SerializeToString(calendar);
                return serializedCalendar;
            }
        }
    }
}
