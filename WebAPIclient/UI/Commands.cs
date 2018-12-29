using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIclient.Models;
using WebAPIclient.Processors;
using WebAPIclient.Services;

namespace WebAPIclient.UI
{
    public class Commands
    {
        private static readonly Dictionary<string, Func<Task>> _commands = new Dictionary<string, Func<Task>>();
        private static List<string> _cities = new List<string>()
        {
            "Moscow",
            "Minsk",
            "London",
            "Tokyo",
            "Warsaw",
        };

        public Commands()
        {
            _commands.Add("/help", Help);
            _commands.Add("/default", DefaultCity);
            _commands.Add("/forecast", Forecast);
            _commands.Add("/list", CityList);

        }

        public void ValidateInput(string input)
        {
            if (_commands.FirstOrDefault(x => x.Key == input).Value != null)
                _commands.FirstOrDefault(x => x.Key == input).Value.Invoke();
            else
            {
                Console.WriteLine("Invalid command entered! Please, try another:");
            }
        }

        public async Task Help()
        {
            Console.WriteLine("--------- LIST OF COMMANDS ----------");
            foreach (var commandsKey in _commands.Keys)
            {
                Console.WriteLine($"{commandsKey}");
            }
            Console.WriteLine("-------------------------------------");
        }

        public async Task CityList()
        {
            foreach (var city in _cities)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine("Please enter the name of the preferred city:");
            var input = Console.ReadLine();
            await CreateForecast(input);
        }

        public async Task DefaultCity()
        {
            await CreateForecast("London");
        }

        public async Task Forecast()
        {
            Console.WriteLine("Please enter city name:");
            var city = Console.ReadLine();
            await CreateForecast(city);
        }

        public async Task CreateForecast(string city)
        {
            try
            {
                Console.WriteLine("Please enter the amount of forecasts:");
                var count = Console.ReadLine();
                var data = await WeatherProcessor.LoadWeatherAsync(city, Int32.Parse(count));
                DisplayForecast(data);
            }
            catch (Exception e)
            {
                ErrorLogService.StoreErrorLog(e.ToString());
            }
        }

        public void DisplayForecast(ModelList weather)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"The city is: {weather.city.CityName}");
            foreach (var forecast in weather.List)
            {
                Console.WriteLine($"FORECAST TIME: {forecast.ForecastDateTime}");
                Console.WriteLine($"The temperature is: {forecast.Main.Temp} C");
                Console.WriteLine($"The MIN temperature is: {forecast.Main.TempMin} C");
                Console.WriteLine($"The MAX temperature is: {forecast.Main.TempMax} C");
                Console.WriteLine($"The pressure is: {forecast.Main.Pressure}hPA");
                Console.WriteLine($"The humidity is: {forecast.Main.Humidity}%");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
