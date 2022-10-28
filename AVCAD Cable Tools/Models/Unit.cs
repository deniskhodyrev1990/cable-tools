using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Models
{
    //Our internal units are millimeters so we need to have a table with user units
    public class Unit
    {
        public long Id { get; set; }
        public double Multiplier { get; }
        public string Name { get; }


        public Unit()
        {

        }

        //public Unit(String name, double multiplier)
        //{
        //    Name = name;
        //    Multiplier = multiplier;
        //}

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
