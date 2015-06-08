using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncallPushService
{
    class OncallCellDTO
    {
        public int Id { get; set; }

        public string OncallName { get; set; }

        public int OncallShift { get; set; }

        public DateTime OncallDate { get; set; }
        
    }
}
