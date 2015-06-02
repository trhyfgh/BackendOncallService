using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BackendOncallService.Models
{
    public class OncallCell
    {
        public int Id { get; set; }
        [Required]
        public string OncallName { get; set; }

        public int OncallShift { get; set; }

        public DateTime OncallDate { get; set; }
    }
}