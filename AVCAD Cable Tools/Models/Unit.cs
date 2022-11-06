using System;

namespace AVCAD.Models
{
    //Our internal units are millimeters so we need to have a table with user units
    /// <summary>
    /// For future use.
    /// </summary>
    public class Unit
    {
        public long Id { get; set; }
        public double Multiplier { get; }
        public string Name { get; }

        public override bool Equals(object? obj)
        {
            return obj is Unit unit && Name == unit.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
