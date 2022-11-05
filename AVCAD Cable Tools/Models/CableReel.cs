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

        public CableReel(CableReel cr)
        {
            this.Id = cr.Id;
            this.Name = cr.Name;
            this.Length = cr.Length;
            this.CableType = cr.CableType;
        }

        public override bool Equals(object? obj)
        {
            return obj is CableReel cr && Name == cr.Name && Length == cr.Length && CableType == cr.CableType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Length, CableType);
        }

        public override string ToString()
        {
            return $"{Name} {Length}";
        }

    }
}
