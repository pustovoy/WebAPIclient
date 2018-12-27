using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIclient.Processors;

namespace WebAPIclient.UI
{
    public class Commands
    {
        private static readonly Dictionary<string, Func<Task>> _commands = new Dictionary<string, Func<Task>>();

        public Commands()
        {
            _commands.Add("/help", Help);
            _commands.Add("/randomcity", RandomCity);

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
            Console.WriteLine("/help");
            Console.WriteLine("/randomcity");
            Console.WriteLine("-------------------------------------");
        }

        public async Task RandomCity()
        {
            var weather = await WeatherProcessor.LoadWeatherAsync("London");
            Console.WriteLine($"The city is: {weather.name}");
            Console.WriteLine($"The temperature is: {weather.temp}");
            Console.WriteLine($"The weather description is: {weather.description}");
        }
    }
}
