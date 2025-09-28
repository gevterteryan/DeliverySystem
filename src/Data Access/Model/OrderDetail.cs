using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Model
{
    public class OrderDetail
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }  
        public byte ItemCount { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
