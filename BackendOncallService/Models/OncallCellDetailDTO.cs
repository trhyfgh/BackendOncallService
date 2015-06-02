using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendOncallService.Models
{
    public class OncallCellDetailDTO
    {
        public int Id { get; set; }

        public string OncallName { get; set; }

        public int OncallShift { get; set; }

        public DateTime OncallDate { get; set; }
    }
}