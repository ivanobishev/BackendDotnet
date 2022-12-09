using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDotnetModel
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        public int Id_Owner { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool DriverLicense { get; set; }
    
    }
}
