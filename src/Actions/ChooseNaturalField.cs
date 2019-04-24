using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        public static void CollectInput(Farm farm, ICompostable plant)
        {
            Console.Clear();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Natural Field {farm.NaturalFields[i].getCount()}");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            choice = choice - 1;
            if (!farm.NaturalFields[choice].AddResource(plant))
            {
                Console.WriteLine($"Natural Field {choice + 1} is at max capacity!");
                Console.ReadLine();
                ChooseNaturalField.CollectInput(farm, plant);
            }
            else
            {
                Console.WriteLine($"You added {plant} to Natural Field {choice + 1}!");
                Console.ReadLine();
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<INatural>(animal, choice);

        }
    }
}