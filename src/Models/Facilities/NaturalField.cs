using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<ICompostable>, ICompost_Seed
    {
        private int _capacity = 2;
        private Guid _id = Guid.NewGuid();

        private List<ICompostable> _plants = new List<ICompostable>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public bool AddResource(ICompostable plant)
        {
            if (_plants.Count < _capacity)
            {
                _plants.Add(plant);
                return true;
            }
            else
            {

                return false;
            }
        }
        public int getCount()
        {
            return _plants.Count;
        }
        public bool AddResource(List<ICompostable> plants)  // TODO: Take out this method for boilerplate
        {
            if (_plants.Count + plants.Count <= _capacity)
            {
                _plants.AddRange(plants);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}