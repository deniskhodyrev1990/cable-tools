using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Models
{
    public class CableReel
    {
        public long Id { get; set; }
        public double Length { get; set; }
        public string Name { get; set; }
        public CableType CableType { get; set; }

        public CableReel()
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is CableReel cr && Name == cr.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

    }
}
