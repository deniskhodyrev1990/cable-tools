using System;

namespace AVCAD.Models
{
    /// <summary>
    /// Cable type class from an SQLite database.
    /// </summary>
    public class CableType
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string? AWG { get; set; }
        public double? MaxLength { get; set; }

        public CableType()
        {

        }

        //Constructor
        public CableType(string type)
        {
            Type = type;
        }

        //Standard override methods.
        public override bool Equals(object? obj)
        {
            return obj is CableType ct && Type == ct.Type && MaxLength == ct.MaxLength;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, MaxLength);
        }

        public override string ToString()
        {
            return $"{Type}";
        }
    }
}
