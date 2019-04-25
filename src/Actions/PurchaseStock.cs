using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class PurchaseStock
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Cow");
            Console.WriteLine("2. Ostrich");

            Console.WriteLine();
            Console.WriteLine("What are you buying today?");

            Console.Write("> ");
            string choice = Console.ReadLine();


            switch (Int32.Parse(choice))
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("How many Cows would you like to buy?");
                    Console.Write("> ");
                    string a = Console.ReadLine();
                    int amount = Int32.Parse(a);
                    ChooseGrazingField.CollectInput(farm, amount, typeof(Cow));
                    // ChooseGrazingField.CollectInput(farm, new Cow());
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("How many Ostrich would you like to buy?");
                    Console.Write("> ");
                    string a1 = Console.ReadLine();
                    int amount1 = Int32.Parse(a1);
                    ChooseGrazingField.CollectInput(farm, amount1, typeof(Ostrich));
                    // ChooseGrazingField.CollectInput(farm, new Ostrich());
                    break;
                default:
                    break;
            }
        }
    }
}