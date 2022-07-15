using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.Models
{
    public class TransactionsReport
    {
        public string TransactionsDate { get; set; }
        public string HostRequestTime { get; set; }
        public string PosTerminalId { get; set; }
        public string PosMerchantId { get; set; }
    }
}
