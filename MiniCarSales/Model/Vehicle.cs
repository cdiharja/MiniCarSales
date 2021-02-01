using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarSales.Model
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ElementTypeAttribute("string", "string", "textbox",200)]
        public string Make { get; set; }

        [ElementTypeAttribute("string", "string", "textbox",300)]
        public string Model { get; set; }
    }
    interface IVehicle
    {

    }
}
