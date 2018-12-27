using System;
using WebAPIclient.Controllers;
using WebAPIclient.UI;

namespace WebAPIclient
{
    class Program
    {
        static Commands cmd = new Commands();
        static void Main(string[] args)
        {
            ApiController.InitializeClient();
            Console.WriteLine("Welcome to the Weather App!");
            Console.WriteLine("For a list of commands type /help");
            while (true)
            {
                cmd.ValidateInput(Console.ReadLine());               
            }
        }
    }
}
