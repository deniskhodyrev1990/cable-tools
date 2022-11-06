namespace AVCAD.Models
{
    /// <summary>
    /// Cable class that we gets from the excel file
    /// </summary>
    public class Cable
    {
        //Default fields
        public string CableNumber { get; set; }
        public string SysnameOut { get; set; }
        public string ConnectorOut { get; set; }
        public string DescriptionOut { get; set; }
        public string LocationOut { get; set; }
        public string ModelOut { get; set; }
        public string SysnameIn { get; set; }
        public string ConnectorIn { get; set; }
        public string DescriptionIn { get; set; }
        public string LocationIn { get; set; }
        public string ModelIn { get; set; }
        public CableType CableType { get; set; }
        public double CableLength { get; set; }
        public double ExtraLength { get; set; }
        public string MulticoreMembers { get; set; }
        public bool IsMulticore { get; set; }


        //Compare one cable to another.
        public override bool Equals(object? obj)
        {
            return obj is Cable cable && CableNumber == cable.CableNumber &&
                SysnameOut == cable.SysnameOut && ConnectorOut == cable.ConnectorOut && DescriptionOut == cable.DescriptionOut && LocationOut == cable.LocationOut && 
                ModelOut == cable.ModelOut &&
                SysnameIn == cable.SysnameIn && ConnectorIn == cable.ConnectorIn && DescriptionIn == cable.DescriptionIn && LocationIn == cable.LocationIn &&
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
                DescriptionOut,
                LocationOut,
                ModelOut,
                SysnameIn,
                ConnectorIn,
                DescriptionIn,
                LocationIn,
                ModelIn,
                CableType,
                CableLength
            }.GetHashCode();
        }


    }
}
