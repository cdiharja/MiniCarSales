
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniCarSales.Model
{
    public class Car : Vehicle
    {
        public DateTime CreatedDate { get; set; }

        [ElementTypeAttribute("string", "string", "textbox",400)]
        [MaxLength(4,ErrorMessage="Maximum 4 characters for Engine")]
        public string Engine { get; set; }

        [ElementTypeAttribute("int", "int", "textbox",500)]
        [Range(0, 100, ErrorMessage = "Invalid Number of Door (0-100)")]
        public int NumberOfDoor { get; set; }


        [ElementTypeAttribute("int", "int", "textbox",600)]
        [Range(0, 100, ErrorMessage = "Invalid Number of Wheels (0-100)")]
        public int NumberOfWheels { get; set; }

        [ElementTypeAttribute("Sedan,Hatchback", "CarBodyType", "dropdown",700)]
        [EnumDataType(typeof(CarBodyType))]
        public CarBodyType BodyType { get; set; }

       
    }
    
}
