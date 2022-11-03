using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Models
{
    public class CableType
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string? AWG { get; set; }
        public double? MaxLength { get; set; }

        public CableType()
        {

        }

        public CableType(string type)
        {
            Type = type;
        }

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
