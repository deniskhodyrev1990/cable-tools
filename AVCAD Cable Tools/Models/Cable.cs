using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Vml.Office;
using AVCAD.Models;

namespace AVCAD.Models
{
    //Make leftover for cables
    public class Cable
    {
        public string? CableNumber { get; set; }
        public string? SysnameOut { get; set; }
        public string? ConnectorOut { get; set; }
        public string? PortOut { get; set; }
        public string? LocationOut { get; set; }
        public string? ModelOut { get; set; }
        public string? SysnameIn { get; set; }
        public string? ConnectorIn { get; set; }
        public string? PortIn { get; set; }
        public string? LocationIn { get; set; }
        public string? ModelIn { get; set; }
        public CableType CableType { get; set; }
        public double CableLength { get; set; }

        public bool IsMulticore { get; set; }

        public Cable()
        {

        }

        //Compare one cable to another.
        public override bool Equals(object? obj)
        {
            return obj is Cable cable && CableNumber == cable.CableNumber &&
                SysnameOut == cable.SysnameOut && ConnectorOut == cable.ConnectorOut && PortOut == cable.PortOut && LocationOut == cable.LocationOut && 
                ModelOut == cable.ModelOut &&
                SysnameIn == cable.SysnameIn && ConnectorIn == cable.ConnectorIn && PortIn == cable.PortIn && LocationIn == cable.LocationIn &&
                ModelIn == cable.ModelIn &&
                CableType == cable.CableType;
        }

        //Override the GetHashCode method.
        public override int GetHashCode()
        {
            return new
            {
                CableNumber,
                SysnameOut,
                ConnectorOut,
                PortOut,
                LocationOut,
                ModelOut,
                SysnameIn,
                ConnectorIn,
                PortIn,
                LocationIn,
                ModelIn,
                CableType,
                CableLength
            }.GetHashCode();
        }


    }
}
