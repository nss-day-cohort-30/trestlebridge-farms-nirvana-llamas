using System.Collections.Generic;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Interfaces
{
    public interface IFacility<T>
    {
        double Capacity { get; }

        bool AddResource (T resource);
        bool AddResource (List<T> resources);
    }
}