using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, int amount, Type animalType)
        {
            Console.Clear();



            Console.WriteLine(animalType.ToString());
            Console.ReadKey();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Grazing Field {farm.GrazingFields[i].getCount()}");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            choice = choice - 1;


            if (amount == 1)
            {
                switch (animalType.ToString())
                {
                    case "Trestlebridge.Models.Animals.Cow":
                        Cow cow = new Cow();
                        if (!farm.GrazingFields[choice].AddResource(cow))
                        {
                            Console.WriteLine($"Grazing Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseGrazingField.CollectInput(farm, amount, typeof(Cow));
                        }
                        else
                        {
                            Console.WriteLine($"You add {cow} Grazing Field {choice + 1}!");
                            Console.ReadLine();
                        }
                        break;
                    case "Trestlebridge.Models.Animals.Ostrich":
                        Ostrich ostrich = new Ostrich();
                        if (!farm.GrazingFields[choice].AddResource(ostrich))
                        {
                            Console.WriteLine($"Grazing Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseGrazingField.CollectInput(farm, amount, typeof(Ostrich));
                        }
                        else
                        {
                            Console.WriteLine($"You add {ostrich} Grazing Field {choice + 1}!");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        break;
                }

                // if (!farm.GrazingFields[choice].AddResource(animal))
                // {
                //     Console.WriteLine($"Grazing Field {choice + 1} is at max capacity!");
                //     Console.ReadLine();
                //     ChooseGrazingField.CollectInput(farm, animal);
                // }
                // else
                // {
                //     Console.WriteLine($"You add {animal} Grazing Field {choice + 1}!");
                //     Console.ReadLine();
                // }
            }
            else if (amount > 1)
            {
                switch (animalType.ToString())
                {
                    case "Trestlebridge.Models.Animals.Cow":
                        List<IGrazing> cows = new List<IGrazing>();
                        for (int i = 0; i < amount; i++)
                        {
                            cows.Add(new Cow());
                        }
                        if (!farm.GrazingFields[choice].AddResource(cows))
                        {
                            Console.WriteLine($"Grazing Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseGrazingField.CollectInput(farm, amount, typeof(Cow));
                        }
                        else
                        {
                            Console.WriteLine($"You add {amount} cows to Grazing Field {choice + 1}!");
                            Console.ReadLine();
                        }
                        break;
                    case "Trestlebridge.Models.Animals.Ostrich":
                        List<IGrazing> ostriches = new List<IGrazing>();
                        for (int i = 0; i < amount; i++)
                        {
                            ostriches.Add(new Ostrich());
                        }
                        if (!farm.GrazingFields[choice].AddResource(ostriches))
                        {
                            Console.WriteLine($"Grazing Field {choice + 1} is at max capacity!");
                            Console.ReadLine();
                            ChooseGrazingField.CollectInput(farm, amount, typeof(Ostrich));
                        }
                        else
                        {
                            Console.WriteLine($"You add {amount} ostriches to Grazing Field {choice + 1}!");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        break;
                }
            }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}