#Giver adgang til Console m.m.
using System;

#projektets navn (samler koden)
namespace SparePartsInventoryAssistant
{
    # her ligger programmet
    class Program
    {
        # programmet starter her
        static void Main(string[] args)
        {
        
            # vores lagerliste med 3 dele
            string[] inventory = { "hydraulic pump", "PLC module", "servo motor" };

            # velkomst og hjælp til bruger
            Console.WriteLine("Hej! Welcome to the spare parts inventory.");
            Console.WriteLine("Type the part name, 'list' to see all parts, or 'exit' to quit.");

            # holder programmet kørende
            bool running = true;

          
            # gentag indtil vi stopper
            while (running)
            {
                # spørg brugeren om ønsket del
                Console.Write("\nWhich part do you need? ");
                # læs tekst, lav null til tom streng, fjern mellemrum
                string inputRaw = Console.ReadLine() ?? "";
                string input = inputRaw.Trim();

                # tomt svar? så spørg igen
                if (input.Length == 0) continue; // tomt input -> spørg igen

            
                # hvis bruger skriver 'exit' (uanset store/små bogstaver)
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    # sig farvel og stop
                    Console.WriteLine("Bye!");
                    running = false;
                    continue;
                }

       
                # tjek om bruger vil se lagerliste
                string lower = input.ToLower();
                if (lower.Contains("any") || lower.Contains("stock") ||
                    lower.Contains("parts") || input.Equals("list", StringComparison.OrdinalIgnoreCase))
                {
                    # skriv antal og vis alle dele
                    Console.WriteLine($"\nWe have {inventory.Length} part(s) in stock:");
                    # gå igennem hver del og skriv den
                    foreach (var part in inventory)
                    {
                        Console.WriteLine($"- {part}");
                    }
                    # tilbage og spørg igen
                    continue;
                }

                # find om ønsket del findes (case-insensitive)
                bool found = Array.Exists(
                    inventory,
                    p => p.Equals(input, StringComparison.OrdinalIgnoreCase)
                );

                # hvis vi har delen: sig det og stop
                if (found)
                {
                    Console.WriteLine($"I have {input} here for you. Bye!");
                    running = false; // afslut efter fund
                }
                else
                {
                    # ellers: sig at vi ikke har den
                    Console.WriteLine($"I am afraid we don’t have any '{input}' in the inventory.");
                }
            }
        }
    }
}
