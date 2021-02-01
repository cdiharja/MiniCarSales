using MiniCarSales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MiniCarSales.Services
{
    public class HelperService
    {   static HelperService()
        {

        }
        public HomeData GenerateHomeData<T>(T enumType)
        {   var homeData = new HomeData();
            
            foreach (int i in Enum.GetValues(enumType.GetType()))
            {   var vehicleMetaData = new VehicleMetaData();
                vehicleMetaData.VehicleTypeName = Enum.GetName(enumType.GetType(), i);
                vehicleMetaData.VehicleTypeValue = i;
                try
                {
                    var myPropertyInfo = Type.GetType($"MiniCarSales.Model.{vehicleMetaData.VehicleTypeName}").GetProperties();

                    foreach (var prop in myPropertyInfo)
                    {
                        var attrs = System.Attribute.GetCustomAttributes(prop);
                        foreach (var attr in attrs)
                        {
                            if (attr is ElementTypeAttribute)
                            {
                                ElementTypeAttribute a = (ElementTypeAttribute)attr;
                                vehicleMetaData.PropertiesData.Add(new PropertyData
                                {
                                    PropertyName = prop.Name,
                                    PropertyFormatName = a.Format,
                                    PropertyValidationTypeName = a.ValidationName,
                                    PropertyElementName = a.Element,
                                    PropertySortOrder = a.SortOrder
                                });
                            }
                        }
                    }
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine($"Type is null ${ex.StackTrace}");
                }
               
                homeData.vehiclesMetaData.Add(vehicleMetaData);
            }
            return homeData;           
        }
    }
}
