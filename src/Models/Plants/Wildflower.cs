using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, ICompostable
    {
        private int _compostProduced = 20;
        public string Type { get; } = "Wildflower";



        public override string ToString()
        {
            return $"Wildflower. Wild!";
        }

        public string Product { get; } = "Compost";
        public double Compose()
        {
            return _compostProduced;
        }
    }
}