using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, ICompostable
    {
        private int _seedsProduced = 10;
        private int _compostProduced = 20;
        public string Type { get; } = "Sunflower";

        public double Harvest()
        {
            return _seedsProduced;
        }

        public override string ToString()
        {
            return $"Sunflower. Yes!";
        }

        public string Product { get; }
        public double Compose()
        {
            return _compostProduced;
        }
    }
}