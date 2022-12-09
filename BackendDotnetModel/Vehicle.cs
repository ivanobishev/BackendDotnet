using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDotnetModel
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        public int Id_Vehicle { get; set; }
        public string? Brand { get; set; }
        public string? Vin { get; set; }
        public string? Color { get; set; }
        public string? Year { get; set; }
        [ForeignKey("Owner")]
        public int Owner_Id { get; set; }

    }
}
