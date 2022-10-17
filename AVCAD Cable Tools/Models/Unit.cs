using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Models
{
    //Our internal units are millimeters so we need to have a table with user units
    public class Unit
    {
        public string Name { get; }
        public double Multiplier { get; }

        public Unit(String name, double multiplier)
        {
            Name = name;
            Multiplier = multiplier;
        }

        public override bool Equals(object? obj)
        {
            return obj is Unit unit && Name == unit.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

    }
}
