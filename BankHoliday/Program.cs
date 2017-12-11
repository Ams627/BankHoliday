using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace BankHoliday
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                var uri = "https://www.gov.uk/bank-holidays.json";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(uri);
                var jsonContent = response.Content.ReadAsStringAsync().Result;

                var holidayList = Root.FromJson(jsonContent);
                var outputXML = new XDocument(new XElement("BankHolidays",
                               new XElement("HolidayList",
                                        new XAttribute("Region", "EnglandWales"),
                                        holidayList.EnglandAndWales.BankHolidays
                                        .Select(x => new XElement("Day",
                                            new XAttribute("Date", $"{x.Date:yyyy-MM-dd}"),
                                            new XAttribute("Title", x.Title)))),
                               new XElement("HolidayList",
                                        new XAttribute("Region", "Scotland"),
                                        holidayList.Scotland.BankHolidays
                                        .Select(x => new XElement("Day",
                                            new XAttribute("Date", $"{x.Date:yyyy-MM-dd}"),
                                            new XAttribute("Title", x.Title))))));
                outputXML.Save("q:\\temp\\o1.xml");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
