using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Models
{
    public class CableType
    {
        public string Type { get; set; }
        public CableType(string type)
        {
            Type = type;
        }

        public override bool Equals(object? obj)
        {
            return obj is CableType ct && Type == ct.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type);
        }
    }
}
