using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChooseNPField
    {
        public static void CollectInput(Farm farm, int amount, Type plantType)
        {

            Console.WriteLine(plantType);
            Console.ReadKey();
            IResource plant = new Sunflower();

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
                    if (amount == 1)
                    {

                        if (!farm.NaturalFields[Fields[choice].Key].AddResource((ICompostable)plant))
                        {
                            Console.WriteLine($"Natural Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseNPField.CollectInput(farm, amount, typeof(Sunflower));
                        }
                        else
                        {
                            Console.WriteLine($"You added {plant} to Natural Field {choice + 1}!");
                            Console.ReadLine();
                        }
                    }
                    else if (amount > 1)
                    {
                        List<ICompostable> plants = new List<ICompostable>();
                        for (int i = 0; i < amount; i++)
                        {
                            plants.Add(new Sunflower());
                        }

                        if (!farm.NaturalFields[Fields[choice].Key].AddResource(plants))
                        {
                            Console.WriteLine($"Natural Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseNPField.CollectInput(farm, amount, plantType);
                        }
                        else
                        {
                            Console.WriteLine($"You added {plant} to Natural Field {choice + 1}!");
                            Console.ReadLine();
                        }
                    }
                    break;
                case "Trestlebridge.Models.Facilities.PlowedField":
                    if (amount == 1)
                    {
                        if (!farm.PlowedFields[Fields[choice].Key].AddResource((ISeedProducing)plant))
                        {
                            Console.WriteLine($"Plowed Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseNPField.CollectInput(farm, amount, plantType);
                        }
                        else
                        {
                            Console.WriteLine($"You added {plant} to plowed Field {choice + 1}!");
                            Console.ReadLine();
                        }
                    }
                    else if (amount > 1)
                    {

                        List<ISeedProducing> plants = new List<ISeedProducing>();
                        for (int i = 0; i < amount; i++)
                        {
                            plants.Add(new Sunflower());
                        }
                        if (!farm.PlowedFields[Fields[choice].Key].AddResource(plants))
                        {
                            Console.WriteLine($"Plowed Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseNPField.CollectInput(farm, amount, plantType);
                        }
                        else
                        {
                            Console.WriteLine($"You added {plants.Count()} {plant}s to plowed Field {choice + 1}!");
                            Console.ReadLine();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}