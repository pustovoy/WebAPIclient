using System;
using System.Threading.Tasks;
using WebAPIclient.Controllers;
using WebAPIclient.Processors;
using WebAPIclient.UI;

namespace WebAPIclient
{
    class Program
    {
        static Commands cmd = new Commands();
        static void Main(string[] args)
        {
            HttpApiController.InitializeClient();
            Console.ForegroundColor = ConsoleColor.Green;

            //Console.WriteLine("Welcome to the Weather App!");
            //Console.WriteLine("For a list of commands type /help");

            Console.WriteLine($"Welcome tp the GITHUB WebHTTPClient!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            GitHubProcessor GHProcessor = new GitHubProcessor();
            GHProcessor.EndPoint = "https://api.github.com/user";
            Console.WriteLine("YOUR RESPONSE IS:");
            Task t = new Task(async () => await GHProcessor.PatchAsync());
            t.Start();
            Console.ReadLine();


            //while (true)
            //{
            //    cmd.ValidateInput(Console.ReadLine());               
            //}
        }
    }
}
