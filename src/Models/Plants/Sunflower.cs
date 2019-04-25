using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, ICompostable
    {
        private int _seedsProduced = 10;
        private int _compostProduced = 20;
        public string Type { get; } = "Sunflower";
        private Guid _id = Guid.NewGuid();

        public double Harvest()
        {
            return _seedsProduced;
        }

        public override string ToString()
        {
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
            return $"Sunflower {shortId} Yes!";
        }

        public string Product { get; }
        public double Compose()
        {
            return _compostProduced;
        }
    }
}