using Common.Contract.Models;
using EmailServiceProvider;
using System.Text.RegularExpressions;

namespace WebScrapingProject
{
    public class GetDataEngine
    {
        public void GetWaitTime()
        {
            CityModel cityModel = new CityModel();
            string message = "";
            foreach (var city in cityModel.Cities)
            {
                string waitTime = GetData(city.CityId).Result;

                var numbers = Regex.Matches(waitTime, @"[0-9]+"); //use regular expression to find match for numeric number

                foreach(Match number in numbers)
                {

                    if (int.Parse(number.Value) <= 100)
                    {
                        message += $"City of {city.CityName}'s wait time is {number.Value} days\n\n";
                    }
                }
            }
            message += "\n\nGet Ready to Apply";
            EmailNotificationProvider.SendEmail("royjianxue@yahoo.com", message, "Visa Waiting Time");
            Console.WriteLine("");
            Console.WriteLine("Please get ready to Apply.");

        }    

        public async Task<string> GetData(string cityId)
        {
            // https://travel.state.gov/content/travel/resources/database/database.getVisaWaitTimes.html?cid=P206&aid=VisaWaitTimesHomePage
            var baseURL = "https://travel.state.gov/content/travel/resources/database/database.getVisaWaitTimes.html?cid=";
            using var client = new HttpClient();
            Uri uri = new Uri(baseURL + cityId + "&aid=VisaWaitTimesHomePage"); // e.g cityId = "P206" Toronto
            var builder = new UriBuilder(uri);
            var completeURL = builder.ToString();
            var response = await client.GetAsync(completeURL);
            var content = await response.Content.ReadAsStringAsync();

            string[] result = content.Trim().Split(","); //  trimmed and separated string by comma. array is now e.g {"26 days", "56 days“, "99 days", "10 days"}

            return result[2];  // VISA application wait time for non immigrants is the 3rd element in the array
        }
    }
}
