using System;

namespace AVCAD.Models
{
    /// <summary>
    /// Cable Reel class that we get from an SQLite database
    /// </summary>
    public class CableReel
    {
        //Fields
        public long Id { get; set; }
        public double Length { get; set; }
        public string Name { get; set; }
        public CableType CableType { get; set; }

        //Equal methd
        public override bool Equals(object? obj)
        {
            return obj is CableReel cr && Name == cr.Name && Length == cr.Length && CableType == cr.CableType;
        }
        //GetHashCode override
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Length, CableType);
        }
        //To string override
        public override string ToString()
        {
            return $"{Name} {Length}";
        }

    }
}
