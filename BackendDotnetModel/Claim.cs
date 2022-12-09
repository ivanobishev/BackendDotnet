using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDotnetModel
{
    [Table("Claim")]
    public class Claim
    {
        [Key]
        public int Id_Claim { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateOnly Date { get; set; }
        [ForeignKey("Vehicle")]
        public int Vehicle_Id { get; set; }

    }
}
