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

            List<KeyValuePair<int, ICompost_Seed>> Fields = new List<KeyValuePair<int, ICompost_Seed>>();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                // Console.WriteLine($"{i + 1}. Natural Field {farm.NaturalFields[i].getCount()}");
                Fields.Add(new KeyValuePair<int, ICompost_Seed>(i, farm.NaturalFields[i]));
            }

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                // Console.WriteLine($"{i + 1}. Plowed Field {farm.PlowedFields[i].getCount()}");
                Fields.Add(new KeyValuePair<int, ICompost_Seed>(i, farm.PlowedFields[i]));
            }

            for (int i = 0; i < Fields.Count; i++)
            {

                {
                   
                    switch (Fields[i].Value.GetType().ToString())
                    {
                        case "Trestlebridge.Models.Facilities.NaturalField":
                            Console.WriteLine($"{i + 1}. Natural Field {Fields[i].Value.getCount()}");
                            break;
                        case "Trestlebridge.Models.Facilities.PlowedField":
                            Console.WriteLine($"{i + 1}. Plowed Field {Fields[i].Value.getCount()}");
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            choice = choice - 1;

            // foreach (KeyValuePair<int, ICompost_Seed> obj in Fields[choice])
            switch (Fields[choice].Value.GetType().ToString())
            {
                case "Trestlebridge.Models.Facilities.NaturalField":
                    if (!farm.NaturalFields[Fields[choice].Key].AddResource((ICompostable)plant))
                    {
                        Console.WriteLine($"Natural Field {choice + 1} is at max capacity!");
                        Console.ReadLine();
                        ChooseNaturalField.CollectInput(farm, (ICompostable)plant);
                    }
                    else
                    {
                        Console.WriteLine($"You added {plant} to Natural Field {choice + 1}!");
                        Console.ReadLine();
                    }
                    break;
                case "Trestlebridge.Models.Facilities.PlowedField":
                    if (!farm.PlowedFields[Fields[choice].Key].AddResource((ISeedProducing)plant))
                    {
                        Console.WriteLine($"Plowed Field {choice + 1} is at max capacity!");
                        Console.ReadLine();
                        ChoosePlowedField.CollectInput(farm, (ISeedProducing)plant);
                    }
                    else
                    {
                        Console.WriteLine($"You added {plant} to plowed Field {choice + 1}!");
                        Console.ReadLine();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}