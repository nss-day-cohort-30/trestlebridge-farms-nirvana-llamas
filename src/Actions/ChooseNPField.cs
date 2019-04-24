using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseNPField
    {
        public static void CollectInput(Farm farm, IResource plant)
        {
            Console.Clear();

            List<Dictionary<int, ICompost_Seed>> Fields = new List<Dictionary<int, ICompost_Seed>>();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Natural Field {farm.NaturalFields[i].getCount()}");
Dictionary<int, ICompost_Seed> Nplant = new Dictionary<int, ICompost_Seed>(){};
Nplant.Add(i, farm.NaturalFields[i]);
                Fields.Add(Nplant);
            }

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Plowed Field {farm.PlowedFields[i].getCount()}");
                Dictionary<int, ICompost_Seed> Nplant = new Dictionary<int, ICompost_Seed>() { };
                Nplant.Add(i, farm.NaturalFields[i]);
                Fields.Add(Nplant);
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            choice = choice - 1;
            // if (!farm.NaturalFields[choice].AddResource(plant))
            // {
            //     Console.WriteLine($"Natural Field {choice + 1} is at max capacity!");
            //     Console.ReadLine();
            //     ChooseNaturalField.CollectInput(farm, plant);
            // }
            // else
            // {
            //     Console.WriteLine($"You added {plant} to Natural Field {choice + 1}!");
            //     Console.ReadLine();
            // }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<INatural>(animal, choice);

        }
    }
}