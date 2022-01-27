﻿using Schalex.StringCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Services
{
    public class ConsoleCommunicator : IConsoleCommunicator
    {
        public string GetInput()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();

            ArgumentNullException.ThrowIfNull(input);

            return input;
        }

        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to Maersk StringCalculator!");
            Console.WriteLine("This calculator only supports "); // TODO: add instructions
            Console.WriteLine(@"Type ""q"" to exit the application.");
        }
    }
}