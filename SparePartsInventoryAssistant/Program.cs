// See https://aka.ms/new-console-template for more information

using System;

namespace SparePartsInventoryAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string[] inventory = { "hydraulic pump", "PLC module", "servo motor" };

            Console.WriteLine("Hej! Welcome to the spare parts inventory.");
            Console.WriteLine("Type the part name, 'list' to see all parts, or 'exit' to quit.");

            bool running = true;

          
            while (running)
            {
                Console.Write("\nWhich part do you need? ");
                string inputRaw = Console.ReadLine() ?? "";
                string input = inputRaw.Trim();

                if (input.Length == 0) continue; // tomt input -> spørg igen

            
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Bye!");
                    running = false;
                    continue;
                }

       
                string lower = input.ToLower();
                if (lower.Contains("any") || lower.Contains("stock") ||
                    lower.Contains("parts") || input.Equals("list", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nWe have {inventory.Length} part(s) in stock:");
                    foreach (var part in inventory)
                    {
                        Console.WriteLine($"- {part}");
                    }
                    continue;
                }

                bool found = Array.Exists(
                    inventory,
                    p => p.Equals(input, StringComparison.OrdinalIgnoreCase)
                );

                if (found)
                {
                    Console.WriteLine($"I have {input} here for you. Bye!");
                    running = false; // afslut efter fund
                }
                else
                {
                    Console.WriteLine($"I am afraid we don’t have any '{input}' in the inventory.");
                }
            }
        }
    }
}
