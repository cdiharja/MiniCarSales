using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarSales.Model
{

    public class VehicleMetaData
    {

        public string VehicleTypeName { get; set; }
        public int VehicleTypeValue { get; set; }
        public List<PropertyData> PropertiesData { get; set; }

        public VehicleMetaData()
        {
            PropertiesData = new List<PropertyData>();
        }
    }
    public class PropertyData
    {

        public string PropertyName { get; set; }
        public string PropertyValidationTypeName { get; set; }
        public string PropertyFormatName { get; set; }
        public string PropertyElementName { get; set; }
        public int PropertySortOrder { get; set; }
    }
    public class HomeData
    {
        public List<VehicleMetaData> vehiclesMetaData { get; set; }
        public HomeData()
        {
            vehiclesMetaData = new List<VehicleMetaData>();
        }
    }
}
